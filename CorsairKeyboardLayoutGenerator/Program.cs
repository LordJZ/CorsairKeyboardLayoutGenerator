using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Xml;

namespace CorsairKeyboardLayoutGenerator
{
    class Program
    {
        const string ShiftNumTableName = "_shift";

        static readonly int[] ShiftNumTable = ")!@#$%^&*(".Select(c => (int)c).ToArray();

        class Layout
        {
            public readonly string KeyTableName;
            public readonly int KeySetIndex;
            public readonly string NumTableName;

            public Layout(string keyTableName, int keySetIndex = 0, string numTableName = null)
            {
                KeyTableName = keyTableName;
                KeySetIndex = keySetIndex;
                NumTableName = numTableName;
            }

            public int[] KeyTable => Tables.Letters[KeyTableName];
            public int[] NumberTable => NumTableName != ShiftNumTableName ? Tables.Digits[NumTableName] : ShiftNumTable;
        }

        static readonly Dictionary<string, Layout> Layouts = new Dictionary<string, Layout>
        {
            { "serif bold", new Layout("serif bold", 26, "bold") },
            { "serif bold shift", new Layout("serif bold", 0, ShiftNumTableName) },

            { "serif italic", new Layout("serif italic", 26) },
            { "serif italic shift", new Layout("serif italic", 0, ShiftNumTableName) },

            { "serif bold italic", new Layout("serif bold italic", 26, "bold") },
            { "serif bold italic shift", new Layout("serif bold italic", 0, ShiftNumTableName) },

            { "sans-serif normal", new Layout("sans-serif normal", 26, "sans-serif") },
            { "sans-serif normal shift", new Layout("sans-serif normal", 0, ShiftNumTableName) },

            { "sans-serif bold", new Layout("sans-serif bold", 26, "sans-serif bold") },
            { "sans-serif bold shift", new Layout("sans-serif bold", 0, ShiftNumTableName) },

            { "sans-serif italic", new Layout("sans-serif italic", 26, "sans-serif") },
            { "sans-serif italic shift", new Layout("sans-serif italic", 0, ShiftNumTableName) },

            { "sans-serif bold italic", new Layout("sans-serif bold italic", 26, "sans-serif bold") },
            { "sans-serif bold italic shift", new Layout("sans-serif bold italic", 0, ShiftNumTableName) },

            { "calligraphy normal", new Layout("calligraphy normal", 26) },
            { "calligraphy normal shift", new Layout("calligraphy normal", 0, ShiftNumTableName) },

            { "calligraphy bold", new Layout("calligraphy bold", 26, "bold") },
            { "calligraphy bold shift", new Layout("calligraphy bold", 0, ShiftNumTableName) },

            { "fraktur normal", new Layout("fraktur normal", 26) },
            { "fraktur normal shift", new Layout("fraktur normal", 0, ShiftNumTableName) },

            { "fraktur bold", new Layout("fraktur bold", 26, "bold") },
            { "fraktur bold shift", new Layout("fraktur bold", 0, ShiftNumTableName) },

            { "mono-space normal", new Layout("mono-space normal", 26, "mono-space") },
            { "mono-space normal shift", new Layout("mono-space normal", 0, ShiftNumTableName) },

            { "double-struck bold", new Layout("double-struck bold", 26, "double-struck") },
            { "double-struck bold shift", new Layout("double-struck bold", 0, ShiftNumTableName) },
        };

        static Guid BaseKeyGuid = new Guid("ED6C43DF-DE13-4FFD-B023-542C2500560E");

        static Guid MakeKeyGuid(int codePoint)
        {
            byte[] bytes = BaseKeyGuid.ToByteArray();
            Array.Copy(BitConverter.GetBytes(codePoint), 0, bytes, 16 - 3, 3);
            return new Guid(bytes);
        }

        static Guid BaseLayoutGuid = new Guid("14723125-1CE2-480A-89AA-60BBFA88B22C");

        static Guid MakeLayoutGuid(string name)
        {
            byte[] bytes = BaseLayoutGuid.ToByteArray();
            Array.Copy(BitConverter.GetBytes(DeterministicHashString(name)), 0, bytes, 16 - 4, 4);
            return new Guid(bytes);
        }

        static int DeterministicHashString(string s)
        {
            if (s == null)
                return 0;

            unchecked
            {
                int hash = 23;
                foreach (char c in s)
                {
                    hash = (hash * 31) ^ c;
                }
                return hash;
            }
        }

        static void Main(string[] args)
        {
            string input =
                args.FirstOrDefault() ??
                System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "All profiles.prf");

            string output =
                args.Skip(1).FirstOrDefault() ??
                System.IO.Path.ChangeExtension(input, ".patched" + System.IO.Path.GetExtension(input));

            XmlDocument xml = new XmlDocument();
            xml.Load(input);

            Dictionary<Guid, XmlNode[]> Modes =
                xml.SelectNodes("//device/modes/mode")
                   .Cast<XmlNode>()
                   .GroupBy(n => Guid.Parse(n.SelectSingleNode("id").InnerText))
                   .ToDictionary(n => n.Key, n => n.ToArray());

            XmlNode template =
                Modes.Values.SelectMany(n => n)
                     .First(n => n.SelectSingleNode("name").InnerText == "Symbols Template");

            foreach (KeyValuePair<string, Layout> pair in Layouts)
            {
                string layoutName = pair.Key;
                Layout layout = pair.Value;
                Guid guid = MakeLayoutGuid(layoutName);

                XmlNode[] modes;
                if (Modes.TryGetValue(guid, out modes))
                {
                    foreach (XmlNode mode in modes)
                        DoLayout(layout, mode);
                }
                else
                {
                    XmlNode newMode = template.CloneNode(true);
                    newMode.Attributes.RemoveNamedItem("key");
                    newMode.SelectSingleNode("name").InnerText = "Symbols (" + layoutName + ")";
                    newMode.SelectSingleNode("id").InnerText = guid.ToString("B");
                    newMode.SelectSingleNode("skipped").InnerText = layoutName.Contains("shift") ? "1" : "0";
                    template.ParentNode.InsertAfter(newMode, template);

                    DoLayout(layout, newMode);
                }
            }

            IEnumerable<int> codePoints =
                Layouts.Values.SelectMany(l => (l.NumTableName != null ? l.NumberTable : Enumerable.Empty<int>())
                                                   .Concat(l.KeyTable.Skip(l.KeySetIndex).Take(26)))
                       .Concat(ShiftNumTable)
                       .Distinct();

            XmlNode actionsNode = xml.SelectSingleNode("//Actions");
            HashSet<Guid> actions = new HashSet<Guid>(
                xml.SelectNodes("//Actions/Action")
                   .Cast<XmlNode>()
                   .Select(n => Guid.Parse(n.SelectSingleNode("Id").InnerText)));

            foreach (int cp in codePoints)
            {
                Guid key = MakeKeyGuid(cp);
                if (actions.Contains(key))
                    continue;

                string c = char.ConvertFromUtf32(cp);
                XmlDocumentFragment newAction = xml.CreateDocumentFragment();
                newAction.InnerXml = $@"
<Action version=""7"" Type=""text"">
   <Id>{key.ToString("B")}</Id>
   <Name>Text {SecurityElement.Escape(c)} (U+{cp.ToString("X4")})</Name>
   <Note></Note>
   <Date>2016-03-20</Date>
   <BindCounter>2</BindCounter>
   <Visible>1</Visible>
   <Predefined>0</Predefined>
   <ExecutionHints>
    <ExecEvent>press</ExecEvent>
    <TerminateWhenStartedAgain>false</TerminateWhenStartedAgain>
    <RestartWhenStartedAgain>false</RestartWhenStartedAgain>
   </ExecutionHints>
   <RepeatOptions version=""1"">
    <Mode>0</Mode>
    <DelayMode>0</DelayMode>
    <AmountOfRepeats>1</AmountOfRepeats>
    <Delay>1</Delay>
    <RandomDelayFrom>0</RandomDelayFrom>
    <RandomDelayTo>0</RandomDelayTo>
   </RepeatOptions>
   <ActionLighting>{{00000000-0000-0000-0000-000000000000}}</ActionLighting>
   <Text>{SecurityElement.Escape(c)}</Text>
   <CharDelay>0</CharDelay>
   <TextInsertionType>1</TextInsertionType>
  </Action>";

                actionsNode.AppendChild(newAction);
            }

            XmlWriterSettings settings = new XmlWriterSettings
            {
                NewLineChars = "\n",
                Indent = true,
                IndentChars = " "
            };

            using (XmlWriter writer = XmlWriter.Create(output, settings))
                xml.Save(writer);
        }

        static void DoLayout(Layout layout, XmlNode mode)
        {
            XmlNode assignments = mode.SelectSingleNode("assigments");
            int[] letterTable = layout.KeyTable;

            for (int i = 0; i < 26; i++)
            {
                Guid key = MakeKeyGuid(letterTable[layout.KeySetIndex + i]);
                assignments.SelectSingleNode("assigment[@key='" + (char)('A' + i) + "']")
                           .Attributes["action"].InnerText = key.ToString("B");
            }

            if (layout.NumTableName == null)
                return;

            int[] numberTable = layout.NumberTable;

            for (int i = 0; i < 10; i++)
            {
                Guid key = MakeKeyGuid(numberTable[i]);
                assignments.SelectSingleNode("assigment[@key='" + i + "']")
                           .Attributes["action"].InnerText = key.ToString("B");
            }
        }
    }
}
