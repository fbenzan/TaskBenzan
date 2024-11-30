using TaskBenzan.Data.Dtos;
using TaskBenzan.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskBenzan.Data.Repositories;

public interface IClientesRepository
{
    Task<ClienteDto> Buscar(int Id);
    Task<List<ClienteDto>> Consultar(string filtro);
    Task<ClienteDto> Crear(ClienteRequestDto request);
    Task<bool> Eliminar(int Id);
    Task<ClienteDto> Update(ClienteRequestDto request);
}

public class ClientesRepository(IApplicationDbContext db) : IClientesRepository
{
    public async Task<ClienteDto> Crear(ClienteRequestDto request)
    {
        //Declaramos la variable para el envio de datos con EF Core.
        var cliente = Cliente.Crear(request);
        //Agregamos el nuevo objeto a la memoria de EF Core
        db.Clientes.Add(cliente);
        //Persistimos la data en base de datos (Hacemos que EF Core escriba en la base de datos)
        await db.SaveChangesAsync().ConfigureAwait(false);
        //Retornamos el objeto que esta esperando el usuario. El campo Id se llena con la clave generada en base de datos
        return
            cliente //Representa el objeto ya en base de datos
            .ToDto();//Utilizamos el metodo para envolver la data en una nueva capsula, desvinculado de memoria de EF Core.
    }
    public async Task<ClienteDto> Update(ClienteRequestDto request)
    {
        //Asignamo en la variable clienteInDB el registro indicado segun la consulta en LinQ
        var clienteInDB = await db.Clientes //Representa la tabla clientes en base de datos
            .Where(cliente => cliente.Id == request.Id) //Donde el campo Id sea igual al Id solicitado.
            .FirstOrDefaultAsync()//Solo tome el primero, de forma asincrona
            .ConfigureAwait(false);//Optimizamos la tarea para que no mapee el contexto en memoria. 
        if (clienteInDB == null) //Si la variable es nula, detonamos un error de aplicacion.
            throw new Exception("El cliente no exite en la base de datos");
        //Ejecutamos la actualizacion a nivel de memoria.
        var guardar = clienteInDB.Update(request);
        //De ser requerido persistimos los cambios en base de datos (Hacemos que EF Core escriba en la base de datos)
        if (guardar) await db.SaveChangesAsync().ConfigureAwait(false);
        //Retornamos el objeto que esta esperando el usuario. El campo Id se llena con la clave generada en base de datos
        return
            clienteInDB //Representa el objeto ya en base de datos
            .ToDto();//Utilizamos el metodo para envolver la data en una nueva capsula, desvinculado de memoria de EF Core.
    }

    public async Task<List<ClienteDto>> Consultar(string filtro)
    {
        var _filtro = filtro.ToLowerInvariant();
        var clientes = await db.Clientes//Representa la tabla clientes en base de datos
            .AsNoTracking()//Aseguramos que la data a traer no sea vigilada para aplicar cambios.
            .Where(cliente =>
            cliente.Nombre.ToLower().Contains(filtro) ||
            cliente.Apellido.ToLower().Contains(filtro) ||
            cliente.Telefono.ToLower().Contains(filtro)) //Donde el nombre o apellido o telefono coincidan con el requerido
            .Select(cliente => cliente.ToDto()) //Convertimos cada registro a la data envuelta separada de la memoria de EF Core.
            .ToListAsync()//Se obtienen
            .ConfigureAwait(false);
        return clientes;
    }
    public async Task<ClienteDto> Buscar(int Id)
    {
        var cliente = await db.Clientes//Representa la tabla clientes en base de datos
            .AsNoTracking()//Aseguramos que la data a traer no sea vigilada para aplicar cambios.
            .Where(cliente => cliente.Id == Id)//Donde el campo Id sea igual al Id solicitado.
            .Select(cliente => cliente.ToDto()) //Convertimos cada registro a la data envuelta separada de la memoria de EF Core.
            .FirstOrDefaultAsync()//Solo tomamos el primero encontrado de forma asincrona.
            .ConfigureAwait(false);

        if (cliente == null) //Si la variable es nula, detonamos un error de aplicacion.
            throw new Exception($"El cliente '{Id}' no exite en la base de datos");

        return cliente;
    }
    public async Task<bool> Eliminar(int Id)
    {
        var cliente = await db.Clientes//Representa la tabla clientes en base de datos
            .Where(cliente => cliente.Id == Id)//Donde el campo Id sea igual al Id solicitado.
            .FirstOrDefaultAsync()//Solo tomamos el primero encontrado de forma asincrona.
            .ConfigureAwait(false);

        if (cliente == null) //Si la variable es nula, detonamos un error de aplicacion.
            throw new Exception($"El cliente '{Id}' no exite en la base de datos");

        db.Clientes.Remove(cliente);
        await db.SaveChangesAsync().ConfigureAwait(false);
        return true;
    }
}
