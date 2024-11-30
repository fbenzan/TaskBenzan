using TaskBenzan.Data.Dtos;

namespace TaskBenzan.Data.Entities
{
    public class Cliente 
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public static Cliente Crear(ClienteRequestDto request)
        => new()
        {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Telefono = request.Telefono
        };
        public bool Update(ClienteRequestDto request)
        {
            var save = false;
            if (Nombre != request.Nombre)
            {
                Nombre = request.Nombre;
                save = true;
            }
            if (Apellido != request.Apellido)
            {
                Apellido = request.Apellido;
                save = true;
            }
            if (Telefono != request.Telefono)
            {
                Telefono = request.Telefono;
                save = true;
            }
            return save;
        }
        public ClienteDto ToDto() => new ClienteDto(Id, Nombre, Apellido, Telefono);
    }
}
