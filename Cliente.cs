namespace Banco
{
    class Cliente
    {
        private string nombre;
        private int monto;

        public Cliente(string nombre, int monto)
        {
            this.nombre = nombre;
            this.monto = monto;
        }

        public bool DepositarDinero(int cantidad)
        {
            if (cantidad <= 0) return false;

            monto += cantidad;
            return true;
        }

        public bool ExtraerDinero(int cantidad)
        {
            if (monto == 0 || monto - cantidad < 0) return false;

            monto -= cantidad;

            return true;
        }

        public string RetornarNombre()
        {
            return nombre;
        }

        public int RetornarMonto()
        {
            return monto;
        }
    }
}
