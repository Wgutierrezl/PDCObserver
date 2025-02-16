using ControllerObserver.Entidades;
using System.Security.Cryptography.X509Certificates;

namespace FrontObserver.Observer
{
	public class ProductoSujeto : ISujeto
	{
		private List<IObservador> observadores=new List<IObservador>();

		public void AgregarObservador(IObservador observador)
		{
			observadores.Add(observador);
		}

		public void EliminarObservador(IObservador observador)
		{
			
			observadores.Remove(observador);
		}

		public List<string> Notificar(Productos p,string accion)
		{
			//Se crea una lista para poder guardar los mensajes de cada notificacion 
			List<string> Mensajes = new List<string>();
            foreach (var item in observadores)
            {
					var message=item.Actualizar(p, accion);
					Mensajes.Add(message);
            }
			return Mensajes;
        }

		//Metodo para poder buscar el Sujeto que se ha iniciado 
		public IObservador BuscarObservador(int id)
		{
			return observadores!.FirstOrDefault(e => e.ID == id)!;
		}
	}
}
