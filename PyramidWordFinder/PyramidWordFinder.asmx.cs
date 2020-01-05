using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PyramidWordFinder
{
    /// <summary>
    /// Summary description for PyramidWordFinder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class PyramidWordFinder : System.Web.Services.WebService
    {

        public PyramidWordFinder() { }

        [WebMethod]
        public bool CheckForPyramidWord(string strWord)
        {
            try
            {
                if (!string.IsNullOrEmpty(strWord))
                {
                    var letterGroup = strWord.GroupBy(i => i.ToString(), StringComparer.OrdinalIgnoreCase)
                                             .Select(i => i.Count())
                                             .OrderBy(i => i);

                    return letterGroup.SequenceEqual(Enumerable.Range(1, letterGroup.ToList().Count()));
                }

                else
                    return false;
            }

            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
