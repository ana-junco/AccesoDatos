namespace AccesoDatos
{
    internal class Sqlconnection : SqlConnetion
    {
        private string v;

        public Sqlconnection(string v)
        {
            this.v = v;
        }
    }
}