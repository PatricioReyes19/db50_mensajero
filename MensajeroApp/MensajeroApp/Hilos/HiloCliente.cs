using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp.Hilos
{
    class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private IMensajesDAL dal = MensajesDALFactory.CreateDal();

        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese el nombre");
                nombre = Console.ReadLine().Trim();
            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese mensaje: ");
                detalle = Console.ReadLine().Trim();
            } while (detalle == string.Empty || detalle.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"
            };
            lock (dal)
            {
                dal.Save(m);
            }
            clienteSocket.CerrarConexion();
        }
    }
}
