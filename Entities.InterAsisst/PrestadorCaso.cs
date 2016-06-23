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
        public Decimal Kilometros;
        public Decimal Costo;

        public Utils.InterAssist.Constants.PersistOperationType TipoOperacion = Utils.InterAssist.Constants.PersistOperationType.Void;

        public void ObjectToRow(Ticket_Prestador.TICKET_PRESTADORESRow resultRow)
        {
            resultRow.IDTICKETPRESTADOR = this.ID;
            resultRow.IDPRESTADOR = this.Prestador.ID;
            resultRow.IDTIPOSERVICIO = this.TipoServicio.ID;
            resultRow.COMENTARIOS = this.Comentarios;
            resultRow.PERSISTOPERATION = (int)this.TipoOperacion;
            resultRow.COSTO = this.Costo;
            resultRow.KILOMETROS = this.Kilometros;
        }

        public DAL.InterAssist.Datasets.Ticket_Prestador.TICKET_PRESTADORESRow ObjectToRow()
        {
            Ticket_Prestador.TICKET_PRESTADORESRow resultRow = (new Ticket_Prestador.TICKET_PRESTADORESDataTable()).NewTICKET_PRESTADORESRow();

            ObjectToRow(resultRow);

            return resultRow;
        }




        public bool IsNew
        {
            get
            {
                return ID == PersistEntity.NULL_ID;
            }
        }
        

    }
}
