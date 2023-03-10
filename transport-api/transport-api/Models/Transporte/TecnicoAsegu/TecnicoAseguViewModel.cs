using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace transport_api.Models.Transporte.TecnicoAsegu
{
    public class TecnicoAseguViewModel
    {

        public int idTecnicoAsegu { get; set; }
        public string AseguradoAdiTecnicoAsegu { get; set; }
        public string CodigoTecnicoAsegu { get; set; }
        public string NombreTecnicoAsegu { get; set; }
        public string RucTecnicoAsegu { get; set; }
        public string PagadorTecnicoAsegu { get; set; }
        public string CodPolizaTecnicoAsegu { get; set; }
        public string NomPoliTecnicoAsegu { get; set; }
        public string AseguPoliTecnicoAsegu { get; set; }
        public string RelaPoliTecnicoAsegu { get; set; }
        public bool condicion { get; set; }
    }
}