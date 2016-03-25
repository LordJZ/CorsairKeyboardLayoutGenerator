﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsairKeyboardLayoutGenerator
{
    class Tables
    {
public static readonly Dictionary<string, int[]> Letters = new Dictionary<string, int[]>
{
{ "serif normal", new int[] { 305, 567 } },
{ "serif bold", new int[] { 119808, 119809, 119810, 119811, 119812, 119813, 119814, 119815, 119816, 119817, 119818, 119819, 119820, 119821, 119822, 119823, 119824, 119825, 119826, 119827, 119828, 119829, 119830, 119831, 119832, 119833, 119834, 119835, 119836, 119837, 119838, 119839, 119840, 119841, 119842, 119843, 119844, 119845, 119846, 119847, 119848, 119849, 119850, 119851, 119852, 119853, 119854, 119855, 119856, 119857, 119858, 119859 } },
{ "serif italic", new int[] { 119860, 119861, 119862, 119863, 119864, 119865, 119866, 119867, 119868, 119869, 119870, 119871, 119872, 119873, 119874, 119875, 119876, 119877, 119878, 119879, 119880, 119881, 119882, 119883, 119884, 119885, 119886, 119887, 119888, 119889, 119890, 119891, 119892, 8462, 119894, 119895, 119896, 119897, 119898, 119899, 119900, 119901, 119902, 119903, 119904, 119905, 119906, 119907, 119908, 119909, 119910, 119911, 120484, 120485 } },
{ "serif bold italic", new int[] { 119912, 119913, 119914, 119915, 119916, 119917, 119918, 119919, 119920, 119921, 119922, 119923, 119924, 119925, 119926, 119927, 119928, 119929, 119930, 119931, 119932, 119933, 119934, 119935, 119936, 119937, 119938, 119939, 119940, 119941, 119942, 119943, 119944, 119945, 119946, 119947, 119948, 119949, 119950, 119951, 119952, 119953, 119954, 119955, 119956, 119957, 119958, 119959, 119960, 119961, 119962, 119963 } },
{ "sans-serif normal", new int[] { 120224, 120225, 120226, 120227, 120228, 120229, 120230, 120231, 120232, 120233, 120234, 120235, 120236, 120237, 120238, 120239, 120240, 120241, 120242, 120243, 120244, 120245, 120246, 120247, 120248, 120249, 120250, 120251, 120252, 120253, 120254, 120255, 120256, 120257, 120258, 120259, 120260, 120261, 120262, 120263, 120264, 120265, 120266, 120267, 120268, 120269, 120270, 120271, 120272, 120273, 120274, 120275 } },
{ "sans-serif bold", new int[] { 120276, 120277, 120278, 120279, 120280, 120281, 120282, 120283, 120284, 120285, 120286, 120287, 120288, 120289, 120290, 120291, 120292, 120293, 120294, 120295, 120296, 120297, 120298, 120299, 120300, 120301, 120302, 120303, 120304, 120305, 120306, 120307, 120308, 120309, 120310, 120311, 120312, 120313, 120314, 120315, 120316, 120317, 120318, 120319, 120320, 120321, 120322, 120323, 120324, 120325, 120326, 120327 } },
{ "sans-serif italic", new int[] { 120328, 120329, 120330, 120331, 120332, 120333, 120334, 120335, 120336, 120337, 120338, 120339, 120340, 120341, 120342, 120343, 120344, 120345, 120346, 120347, 120348, 120349, 120350, 120351, 120352, 120353, 120354, 120355, 120356, 120357, 120358, 120359, 120360, 120361, 120362, 120363, 120364, 120365, 120366, 120367, 120368, 120369, 120370, 120371, 120372, 120373, 120374, 120375, 120376, 120377, 120378, 120379 } },
{ "sans-serif bold italic", new int[] { 120380, 120381, 120382, 120383, 120384, 120385, 120386, 120387, 120388, 120389, 120390, 120391, 120392, 120393, 120394, 120395, 120396, 120397, 120398, 120399, 120400, 120401, 120402, 120403, 120404, 120405, 120406, 120407, 120408, 120409, 120410, 120411, 120412, 120413, 120414, 120415, 120416, 120417, 120418, 120419, 120420, 120421, 120422, 120423, 120424, 120425, 120426, 120427, 120428, 120429, 120430, 120431 } },
{ "calligraphy normal", new int[] { 119964, 8492, 119966, 119967, 8496, 8497, 119970, 8459, 8464, 119973, 119974, 8466, 8499, 119977, 119978, 119979, 119980, 8475, 119982, 119983, 119984, 119985, 119986, 119987, 119988, 119989, 119990, 119991, 119992, 119993, 8495, 119995, 8458, 119997, 119998, 119999, 120000, 120001, 120002, 120003, 8500, 120005, 120006, 120007, 120008, 120009, 120010, 120011, 120012, 120013, 120014, 120015 } },
{ "calligraphy bold", new int[] { 120016, 120017, 120018, 120019, 120020, 120021, 120022, 120023, 120024, 120025, 120026, 120027, 120028, 120029, 120030, 120031, 120032, 120033, 120034, 120035, 120036, 120037, 120038, 120039, 120040, 120041, 120042, 120043, 120044, 120045, 120046, 120047, 120048, 120049, 120050, 120051, 120052, 120053, 120054, 120055, 120056, 120057, 120058, 120059, 120060, 120061, 120062, 120063, 120064, 120065, 120066, 120067 } },
{ "fraktur normal", new int[] { 120068, 120069, 8493, 120071, 120072, 120073, 120074, 8460, 8465, 120077, 120078, 120079, 120080, 120081, 120082, 120083, 120084, 8476, 120086, 120087, 120088, 120089, 120090, 120091, 120092, 8488, 120094, 120095, 120096, 120097, 120098, 120099, 120100, 120101, 120102, 120103, 120104, 120105, 120106, 120107, 120108, 120109, 120110, 120111, 120112, 120113, 120114, 120115, 120116, 120117, 120118, 120119 } },
{ "fraktur bold", new int[] { 120172, 120173, 120174, 120175, 120176, 120177, 120178, 120179, 120180, 120181, 120182, 120183, 120184, 120185, 120186, 120187, 120188, 120189, 120190, 120191, 120192, 120193, 120194, 120195, 120196, 120197, 120198, 120199, 120200, 120201, 120202, 120203, 120204, 120205, 120206, 120207, 120208, 120209, 120210, 120211, 120212, 120213, 120214, 120215, 120216, 120217, 120218, 120219, 120220, 120221, 120222, 120223 } },
{ "mono-space normal", new int[] { 120432, 120433, 120434, 120435, 120436, 120437, 120438, 120439, 120440, 120441, 120442, 120443, 120444, 120445, 120446, 120447, 120448, 120449, 120450, 120451, 120452, 120453, 120454, 120455, 120456, 120457, 120458, 120459, 120460, 120461, 120462, 120463, 120464, 120465, 120466, 120467, 120468, 120469, 120470, 120471, 120472, 120473, 120474, 120475, 120476, 120477, 120478, 120479, 120480, 120481, 120482, 120483 } },
{ "double-struck bold", new int[] { 120120, 120121, 8450, 120123, 120124, 120125, 120126, 8461, 120128, 120129, 120130, 120131, 120132, 8469, 120134, 8473, 8474, 8477, 120138, 120139, 120140, 120141, 120142, 120143, 120144, 8484, 120146, 120147, 120148, 120149, 120150, 120151, 120152, 120153, 120154, 120155, 120156, 120157, 120158, 120159, 120160, 120161, 120162, 120163, 120164, 120165, 120166, 120167, 120168, 120169, 120170, 120171 } },
};
        public static readonly Dictionary<string, int[]> Digits = new Dictionary<string, int[]>
{
{ "bold", new int[] { 120782, 120783, 120784, 120785, 120786, 120787, 120788, 120789, 120790, 120791 } },
{ "double-struck", new int[] { 120792, 120793, 120794, 120795, 120796, 120797, 120798, 120799, 120800, 120801 } },
{ "sans-serif", new int[] { 120802, 120803, 120804, 120805, 120806, 120807, 120808, 120809, 120810, 120811 } },
{ "sans-serif bold", new int[] { 120812, 120813, 120814, 120815, 120816, 120817, 120818, 120819, 120820, 120821 } },
{ "mono-space", new int[] { 120822, 120823, 120824, 120825, 120826, 120827, 120828, 120829, 120830, 120831 } },
};
    }
}