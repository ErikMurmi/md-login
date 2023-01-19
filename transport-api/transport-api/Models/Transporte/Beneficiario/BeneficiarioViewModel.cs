using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace transport_api.Models.Transporte.Beneficiario
{
    public class BeneficiarioViewModel
    {


        public int idEndosoBene { get; set; }
        public string NumeroPoliza { get; set; }
        public string NumeroApliBene { get; set; }
        public DateTime FechaEndoso { get; set; }
        public string AseguradaBene { get; set; }
        public string AseguradoBene { get; set; }
        public string Beneficiario { get; set; }
        public string ContenidoBene { get; set; }
        public bool condicion { get; set; }

    }
}