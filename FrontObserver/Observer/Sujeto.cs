using ControllerObserver.Entidades;

namespace FrontObserver.Observer
{
	public class Sujeto:IObservador
	{
		public int ID {  get; set; }
		public string? Nombre { get; set; }
		public string? Apellido { get; set; }

		public string Actualizar(Productos Producto, string accion)
		{
			return $"El usuario {Nombre} ; {Apellido} recibio la notificacion del Producto {Producto.NombreProducto} como {accion}";
		}

		public override string ToString()
		{
			return $"Nombre : {Nombre} ; Apellido {Apellido}";
		}

		

	}
}
