using System.ComponentModel.DataAnnotations;

namespace TaskBenzan.Data.Dtos;
/// <summary>
/// Resultado de transaccion
/// </summary>
public record ClienteDto(int Id, string Nombre, string Apellido, string Telefono);

/// <summary>
/// Requisito para crear o actualizar un cliente
/// </summary>
public class ClienteRequestDto: IClienteRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El Apellido es requerido")]
    public string Apellido { get; set; } = null!;
    [Required(ErrorMessage = "El télefono es requerido"), Phone]
    public string Telefono { get; set; } = null!;

    public ClienteDto ToDto() => new(Id,Nombre, Apellido, Telefono);
}
public interface IClienteRequest
{
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El Apellido es requerido")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "El télefono es requerido"), Phone]
    public string Telefono { get; set; }
}