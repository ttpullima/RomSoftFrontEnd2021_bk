using System.Configuration;


namespace Romsoft.GESTIONCLINICA.DataAccess.Core
{
    public static class ConectionStringRepository
    {
        #region Propiedades

        #region ConnectionString

        public static string ConnectionStringSQL
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString;
            }
        }

        #endregion

        #region ConnectionStringName

        public static string ConnectionStringNameSQL
        {
            get
            {
                return "ConnectionStringSQL";
            }
        }


        #endregion

        public static string EsquemaName
        {
            get
            {
                return "Romsoft.";
            }
        }

        #endregion
    }
}
