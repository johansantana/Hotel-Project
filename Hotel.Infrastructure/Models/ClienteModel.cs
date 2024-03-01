﻿namespace Hotel.Infrastructure;

public class ClienteModel
{
    public required int IdCliente { get; set; }
    public string? TipoDocumento { get; set; }
    public string? Documento { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Correo { get; set; }
    public bool Estado { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = new DateTime();
}
