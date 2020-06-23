export interface Cotizacion{
    precioVenta: number;
    precioCompra: number;
    pechaActualizacion: string;
}

export interface Compra{
    IdUsuario: string;
    MontoEnPesos: number;
    CodigoMoneda: string;
}
