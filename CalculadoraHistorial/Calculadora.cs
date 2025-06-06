namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato = 0;
        private double anterior = 0;
        private TipoOperacion op;
        private List<Operacion> historial = new List<Operacion>();
        public void Sumar(double termino)
        {
            anterior = dato;
            dato += termino;
            op = TipoOperacion.Suma;
            historial.Add(new Operacion(anterior, termino, op));
        }
        public void Restar(double termino)
        {
            anterior = dato;
            dato -= termino;
            op = TipoOperacion.Resta;
            historial.Add(new Operacion(anterior, termino, op));
        }
        public void Multiplicar(double termino)
        {
            anterior = dato;
            dato *= termino;
            op = TipoOperacion.Multiplicacion;
            historial.Add(new Operacion(anterior, termino, op));
        }
        public void Dividir(double termino)
        {
            anterior = dato;
            dato /= termino;
            op = TipoOperacion.Division;
            historial.Add(new Operacion(anterior, termino, op));
        }
        public void Limpiar()
        {
            anterior = dato;
            dato = 0;
            op = TipoOperacion.Limpiar;
            historial.Add(new Operacion(anterior, 0, op));
        }
        public double Resultado
        {
            get => dato;
        }
        public List<Operacion> Historial
        {
            get => historial;
        }
    }
    public class Operacion
    {
        private double resultadoAnterior; //resultado previo al calculo actual
        private double nuevoValor; //el valor con el que se opera resultadoAnterior
        private TipoOperacion operador;
        public double Resultado
        {
            /* Lógica para calcular o devolver el resultado */
            get
            {
                switch (operador)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        return resultadoAnterior / nuevoValor;
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        throw new InvalidOperationException("Operación no válida.");
                }
            }
        }
        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operador)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operador = operador;
        }
        public double NuevoValor
        {
            get => nuevoValor;
        }
        public double ResultadoAnterior
        {
            get => resultadoAnterior;
        }
        public TipoOperacion Operador
        {
            get => operador;
        }
    }

    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }
}