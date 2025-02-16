using ControllerObserver.Entidades;

namespace FrontObserver.Observer
{
	public interface IObservador
	{
		public int ID { get; set; }
		string Actualizar(Productos Producto,string accion);
	}
}
