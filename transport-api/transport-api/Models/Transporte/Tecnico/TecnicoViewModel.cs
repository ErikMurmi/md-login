using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace transport_api.Models.Transporte.Tecnico
{
    public class TecnicoViewModel
    {

        public int idTransporteTecnico { get; set; }
        public string ComisioTransTecnico { get; set; }
        public string TasaTransTecnico { get; set; }
        public string NumeroPolizaRiesgosTransTecnico { get; set; }
        public string DiazRetroactiviTransTecnico { get; set; }
        public bool condicion { get; set; }

    }
}