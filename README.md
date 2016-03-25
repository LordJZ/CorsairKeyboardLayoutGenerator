# Corsair Keyboard Layout Generator
This app generates Unicode keyboard "Layouts" for Corsair CUE-enabled keyboards. This allows to use 𝚖𝚘𝚗𝚘𝚜𝚙𝚊𝚌𝚎, 𝙞𝙩𝙖𝙡𝙞𝙘 𝙖𝙣𝙙 𝙗𝙤𝙡𝙙, 𝕠𝕣 𝕖𝕧𝕖𝕟 𝕤𝕠𝕞𝕖 𝓌ℯ𝒾𝓇𝒹 𝓉𝒽𝒾𝓃ℊ𝓈 in places that do not allow HTML or rich text. Copy-paste the weird words from this paragraph to see how it works. A-Z and 0-9 characters are supported. See [this wikipedia article](https://en.wikipedia.org/wiki/Mathematical_Alphanumeric_Symbols#Latin_letters) for a list "layouts".

Useful when you want to send code, math, or emphasized words over a messenger like WhatsApp or Telegram. Also might be useful for security testing because these strings are 𝘯𝘢𝘶𝘨𝘩𝘵𝘺.

## Setup
1. You will need a Corsair keyboard and Corsair software called CUE.
2. In CUE create a new Profile. In that Profile create a Mode called "Symbols Template". This will be the base mode for "layouts". Modify assignments and lighting at will; A-Z and 0-9 assignments will be overriden.
3. Export all profiles to My Documents file "All profiles.prf" (this is the default, see below for non-default).
4. Run CorsairKeyboardLayoutGenerator.exe, it should flash the console window and exit.
5. Import all profiles from My Documents file "All profiles.patched.prf". Click update everywhere.
6. Now you have a ton more Modes in that Profile. "Shift" are the ones that are meant to be used while Shift is pressed, set a key assignment for that (switch to mode while pressed).

### Advanced
  `CorsairKeyboardLayoutGenerator.exe <input_file> <output_file>`
  
Both arguments are optional. Feel free to poke around the source code.

## Known Incompatibilities
1. Firefox doesn't handle unicode input at all. See [this 10 year old bug](https://bugzilla.mozilla.org/show_bug.cgi?id=337252).
2. Notepad++ messes with some Unicode surrogate pairs.
3. Lots of apps and editors, including the Github editor, incorrectly handle the surrogate pairs during editing; viewing is mostly okay.
4. Lots of mobile apps do not support higher Unicode codepoints at all. Send them a Google Play review in 𝗕𝗢𝗟𝗗.

Use a different editor/browser if required, then copy-paste back. Recommended are Chrome, Edge, or built-in windows Notepad.
