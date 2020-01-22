using System;
namespace TareaFacturasLinqr.Clases
{
    public class Factura
    {
        private string observacion;
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        private int idcliente;
        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private float total;
        public float Total
        {
            get { return total; }
            set { total = value; }
        }
        private int anio;
        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }
    }
}
