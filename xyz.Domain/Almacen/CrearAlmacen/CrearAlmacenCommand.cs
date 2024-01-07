namespace xyz.Domain.Almacen.CrearAlmacen;

public record CrearAlmacenCommand(Guid Id, string NombreSucursal, string NombreAdministrador, string Telefono, string Direccion, string Fax, double? NumeroPedidos);
{

}
