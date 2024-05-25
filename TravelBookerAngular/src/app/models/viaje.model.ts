export interface IViaje {
    id:                 number;
    idLocalidadOrigen:  string;
    idLocalidadDestino: string;
    fechaYHora:         string;
    precio:             number;
    butacasReservadas:  number[];
    idColectivo:        number;
}