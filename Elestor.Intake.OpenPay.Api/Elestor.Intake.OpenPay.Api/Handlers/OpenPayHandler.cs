using Openpay;

namespace Elestor.Intake.OpenPay.Api.Handlers
{
    /// <summary>
    ///
    /// </summary>
    public class OpenPayHandler
    {
        private static readonly string _API_KEY = "sk_8c673c762ece48359ed29e4dcb2501d7";

        //"pk_1a559d9438714db7b1b88ae6b5756358"
        private static readonly string MERCHANT_ID = "mwvt7x3ehfnlgluepwng";

        private static readonly bool production = true;

        protected OpenPayHandler()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static OpenpayAPI GetOpenPayInstance()
        {
            return new OpenpayAPI(_API_KEY, MERCHANT_ID);
        }
    }
}