using ControllerObserver.Entidades;

namespace FrontObserver.Observer
{
	public interface ISujeto
	{
		void AgregarObservador(IObservador observador);
		void EliminarObservador(IObservador observador);
		List<string> Notificar(Productos P,string accion);
	}
}
