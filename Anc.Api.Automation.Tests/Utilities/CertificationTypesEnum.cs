namespace Anc.Api.Automation.Tests
{
    public class CertificationTypesEnum
    {
        public enum CertificationTypes
        {
            PMP = 1, CAPM = 2, PgMP = 3, PMI_RMP = 4, PMI_SP = 5, PMI_ACP = 6,
            PfMP = 7, PMI_PBA = 8, AH_MC = 9, DASM = 10, DASSM = 11, DAC = 12,
            DAVSC = 13, CD_MC = 14, CDBA = 15, OTF = 16, OTI = 17, OTO = 18,
            ECC = 19, AM_MC = 20, VSM = 21, BEPM = 22, BETI = 23, CEPBP = 24
        };

        /// <summary>
        /// Getting SKU code for an application
        /// </summary>
        /// <param name="CertificationType">String of Provide application type: Supported Applications: PMP, CAPM, PgMP, PMI-SP, PMI-RMP, PMI-PBA, PMI-ACP & PfMP</param>
        /// <param name="skuTpes">String of Purchasing type Eg: Exam or Retake or Renewal</param>
        /// <returns></returns>
        /// <exception cref="Exception">Certification Type Id or SKU purchase event is not as expected</exception>
        public static string GetSkuCodes(string CertificationType, string skuTpes)
        {
            try
            {
                switch (CertificationType.Replace("_","-").ToUpper())
                {
                    case "PMP":
                        return PMPCodes.GetValueOrDefault(skuTpes);
                    case "CAPM":
                        return CAPMCodes.GetValueOrDefault(skuTpes);
                    case "PGMP":
                        return PgMPCodes.GetValueOrDefault(skuTpes);
                    case "PMI-RMP":
                        return RMPCodes.GetValueOrDefault(skuTpes);
                    case "PMI-SP":
                        return SPCodes.GetValueOrDefault(skuTpes);
                    case "PMI-ACP":
                        return ACPCodes.GetValueOrDefault(skuTpes);
                    case "PFMP":
                        return PfMPCodes.GetValueOrDefault(skuTpes);
                    case "PMI-PBA":
                        return PBACodes.GetValueOrDefault(skuTpes);
                }
            }
            catch
            {
                throw new Exception($"CertificationTypeId: {CertificationType} or SKU types: {skuTpes} is incorrect");
            }
            return new Exception($"CertificationTypeId: {CertificationType} or SKU types: {skuTpes} is incorrect").ToString();
        }

        private static readonly Dictionary<string, string> PMPCodes = new Dictionary<string, string> { { "Exam", "6700020" }, { "Retake", "6700021" }, { "Renewal", "6700070" } };
        private static readonly Dictionary<string, string> CAPMCodes = new Dictionary<string, string> { { "Exam", "6700026" }, { "Retake", "6700027" }, { "Renewal", "6700095" } };
        private static readonly Dictionary<string, string> PgMPCodes = new Dictionary<string, string> { { "Exam", "6700032" }, { "Retake", "6700033" }, { "Renewal", "6700072" } };
        private static readonly Dictionary<string, string> PfMPCodes = new Dictionary<string, string> { { "Exam", "6700050" }, { "Retake", "6700051" }, { "Renewal", "6700073" } };
        private static readonly Dictionary<string, string> RMPCodes = new Dictionary<string, string> { { "Exam", "6700044" }, { "Retake", "6700045" }, { "Renewal", "6700075" } };
        private static readonly Dictionary<string, string> ACPCodes = new Dictionary<string, string> { { "Exam", "6700056" }, { "Retake", "6700057" }, { "Renewal", "6700076" } };
        private static readonly Dictionary<string, string> PBACodes = new Dictionary<string, string> { { "Exam", "6700062" }, { "Retake", "6700063" }, { "Renewal", "6700071" } };
        private static readonly Dictionary<string, string> SPCodes = new Dictionary<string, string> { { "Exam", "6700038" }, { "Retake", "6700039" }, { "Renewal", "6700074" } };
    };
}

