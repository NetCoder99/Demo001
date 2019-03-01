//============================================================================
// John Dugger
// 02/27/2019
// Hard coded list that the DbContext object can access to initialize 
// the database tables.
//============================================================================
using System.Collections.Generic;

namespace WebApp2.Models.Addresses
{
    public class GetStateCodesMEX 
    {
        public static List<StateCode> GetStates()
        {
            List<StateCode> rtn_list = new List<StateCode>();
            rtn_list.Add(new StateCode(2, "AG", "Aguascalientes"));
            rtn_list.Add(new StateCode(2, "BC", "Baja California"));
            rtn_list.Add(new StateCode(2, "BS", "Baja California Sur"));
            rtn_list.Add(new StateCode(2, "CH", "Chihuahua"));
            rtn_list.Add(new StateCode(2, "CL", "Colima"));
            rtn_list.Add(new StateCode(2, "CM", "Campeche"));
            rtn_list.Add(new StateCode(2, "CO", "Coahuila"));
            rtn_list.Add(new StateCode(2, "CS", "Chiapas"));
            rtn_list.Add(new StateCode(2, "DF", "Federal District"));
            rtn_list.Add(new StateCode(2, "DG", "Durango"));
            rtn_list.Add(new StateCode(2, "GR", "Guerrero"));
            rtn_list.Add(new StateCode(2, "GT", "Guanajuato"));
            rtn_list.Add(new StateCode(2, "HG", "Hidalgo"));
            rtn_list.Add(new StateCode(2, "JA", "Jalisco"));
            rtn_list.Add(new StateCode(2, "ME", "México State"));
            rtn_list.Add(new StateCode(2, "MI", "Michoacán"));
            rtn_list.Add(new StateCode(2, "MO", "Morelos"));
            rtn_list.Add(new StateCode(2, "NA", "Nayarit"));
            rtn_list.Add(new StateCode(2, "NL", "Nuevo León"));
            rtn_list.Add(new StateCode(2, "OA", "Oaxaca"));
            rtn_list.Add(new StateCode(2, "PB", "Puebla"));
            rtn_list.Add(new StateCode(2, "QE", "Querétaro"));
            rtn_list.Add(new StateCode(2, "QR", "Quintana Roo"));
            rtn_list.Add(new StateCode(2, "SI", "Sinaloa"));
            rtn_list.Add(new StateCode(2, "SL", "San Luis Potosí"));
            rtn_list.Add(new StateCode(2, "SO", "Sonora"));
            rtn_list.Add(new StateCode(2, "TB", "Tabasco"));
            rtn_list.Add(new StateCode(2, "TL", "Tlaxcala"));
            rtn_list.Add(new StateCode(2, "TM", "Tamaulipas"));
            rtn_list.Add(new StateCode(2, "VE", "Veracruz"));
            rtn_list.Add(new StateCode(2, "YU", "Yucatán"));
            rtn_list.Add(new StateCode(2, "ZA", "Zacatecas"));
            return rtn_list;
        }
    }
}