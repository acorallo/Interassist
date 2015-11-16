using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.InterAssist;
using DAL.InterAssist.Datasets;


namespace Entities.InterAsisst
{

    public class PrestadorCaso
    {

        public int ID { get; set; }
        public Prestador Prestador { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public string Comentarios;
        public Utils.InterAssist.Constants.PersistOperationType TipoOperacion = Utils.InterAssist.Constants.PersistOperationType.Void;

        public void ObjectToRow(Ticket_Prestador.TICKET_PRESTADORESRow resultRow)
        {
            resultRow.IDTICKETPRESTADOR = this.ID;
            resultRow.IDPRESTADOR = this.Prestador.ID;
            resultRow.IDTIPOSERVICIO = this.TipoServicio.ID;
            resultRow.COMENTARIOS = this.Comentarios;
            resultRow.PERSISTOPERATION = (int)this.TipoOperacion;
        }

        public DAL.InterAssist.Datasets.Ticket_Prestador.TICKET_PRESTADORESRow ObjectToRow()
        {
            Ticket_Prestador.TICKET_PRESTADORESRow resultRow = (new Ticket_Prestador.TICKET_PRESTADORESDataTable()).NewTICKET_PRESTADORESRow();

            ObjectToRow(resultRow);

            return resultRow;
        }

        

    }
}
