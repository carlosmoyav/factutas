using System;
namespace TareaFacturasLinqr.Clases
{
    public class Cliente
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
