class Program
{
    static void Main()
    {
        // Define los arreglos
        int[] arreglo1 = { 4, 22 };
        int[] arreglo2 = { 6, 7, 8, };
        int[] arreglo3 = { 2, 8, 9, 12, 5, 4 };
        int[] arreglo4 = { 3, 5, 21, 22, 1 };
        int[] arreglo5 = { 3, 14, 20, 21, 4 };
        int[] arreglo6 = { 2, 7, 10 };
        int[] arreglo7 = { 8, 9, 10, 6, 2, 11 };
        int[] arreglo8 = { 7, 2, 3, 9 };
        int[] arreglo9 = { 8, 12, 11, 7 };
        int[] arreglo10 = { 6, 7, 11 };
        int[] arreglo11 = { 10, 7, 9, 12, 15 };
        int[] arreglo12 = { 3, 9, 11, 15, 13, 14 };
        int[] arreglo13 = { 12, 15, 14 };
        int[] arreglo14 = { 13, 16, 15, 18, 20, 5, 12 };
        int[] arreglo15 = { 11, 12, 13, 14, 16 };
        int[] arreglo16 = { 15, 14, 18, 17 };
        int[] arreglo17 = { 16, 18, 19 };
        int[] arreglo18 = { 14, 16, 17, 19, 20, 21 };
        int[] arreglo19 = { 17, 18, 21 };
        int[] arreglo20 = { 5, 14, 18, 21 };
        int[] arreglo21 = { 19, 18, 20, 4, 22, 5 };
        int[] arreglo22 = { 21, 4, 1 };


        // Crear un diccionario que mapea números de departamento a nombres
        Dictionary<int, string> nombresDepartamentos = new Dictionary<int, string>
        {
            {1, "Peten"},
            {2, "Huehuetenango"},
            {3, "Quiche"},
            {4, "Alta Verapaz"},
            {5, "Baja Verapaz" },
            {6, "San Marcos" },
            {7, "Quetzaltenango" },
            {8, "TotoGod" },
            {9, "Solola" },
            {10, "Retalhuleu" },
            {11, "Suchitepequez" },
            {12, "Chimaltenango" },
            {13, "Sacatepequez" },
            {14, "Guatemala" },
            {15, "Escuintla" },
            {16, "Santa Rosa" },
            {17, "Jutiapa" },
            {18, "Jalapa" },
            {19, "Chiquimula" },
            {20, "El Progreso" },
            {21, "Zacapa" },
            {22, "Izabal" },
        };

        // Crear un diccionario que represente el grafo
        Dictionary<int, List<int>> grafo = new Dictionary<int, List<int>>
        {
            {1, new List<int>(arreglo1)},
            {2, new List<int>(arreglo2)},
            {3, new List<int>(arreglo3)},
            {4, new List<int>(arreglo4)},
            {5, new List<int>(arreglo5)},
            {6, new List<int>(arreglo6)},
            {7, new List<int>(arreglo7)},
            {8, new List<int>(arreglo8)},
            {9, new List<int>(arreglo9)},
            {10, new List<int>(arreglo10)},
            {11, new List<int>(arreglo11)},
            {12, new List<int>(arreglo12)},
            {13, new List<int>(arreglo13)},
            {14, new List<int>(arreglo14)},
            {15, new List<int>(arreglo15)},
            {16, new List<int>(arreglo16)},
            {17, new List<int>(arreglo17)},
            {18, new List<int>(arreglo18)},
            {19, new List<int>(arreglo19)},
            {20, new List<int>(arreglo20)},
            {21, new List<int>(arreglo21)},
            {22, new List<int>(arreglo22)},
        };

        //Menu de opciones
        Console.WriteLine(":v------¡Bienvenido!------v:");
        Console.WriteLine();
        Console.WriteLine("1.)Peten");
        Console.WriteLine("2.)Huehuetenango");
        Console.WriteLine("3.)Quiche");
        Console.WriteLine("4.)Alta Verapaz");
        Console.WriteLine("5.)Baja Verapaz");
        Console.WriteLine("6.)San Marcos");
        Console.WriteLine("7.)Quetzaltenango");
        Console.WriteLine("8.)Totonicapan");
        Console.WriteLine("9.)Solola");
        Console.WriteLine("10.)Retalhuleu");
        Console.WriteLine("11.)Suchitepequez");
        Console.WriteLine("12.)Chimaltenango");
        Console.WriteLine("13.)Sacatepequez");
        Console.WriteLine("14.)Guatemala");
        Console.WriteLine("15.)Escuintla");
        Console.WriteLine("16.)Santa Rosa");
        Console.WriteLine("17.)Jutiapa");
        Console.WriteLine("18.)Jalapa");
        Console.WriteLine("19.)Chiquimula");
        Console.WriteLine("20.)El Progreso");
        Console.WriteLine("21.)Sacapa");
        Console.WriteLine("22.)Izabal");

        Console.WriteLine("Ingrese el número del departamento de inicio:");
        int inicio = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el número del departamento de destino:");
        int objetivo = int.Parse(Console.ReadLine());




        // Realizar una búsqueda en profundidad (DFS) para encontrar el camino
        List<int> camino = BuscarCaminoDFS(grafo, inicio, objetivo);

        if (camino.Count > 0)
        {
            Console.WriteLine("Camino encontrado: " + ObtenerNombresDepartamentos(nombresDepartamentos, camino));
        }
        else
        {
            Console.WriteLine("No se encontró un camino.");
        }
    }

    static List<int> BuscarCaminoDFS(Dictionary<int, List<int>> grafo, int inicio, int objetivo)
    {
        Stack<int> pila = new Stack<int>();
        Dictionary<int, int> padres = new Dictionary<int, int>();

        pila.Push(inicio);
        padres[inicio] = -1;

        while (pila.Count > 0)
        {
            int actual = pila.Pop();

            if (actual == objetivo)
            {
                List<int> camino = new List<int>();
                int nodo = objetivo;
                while (nodo != -1)
                {
                    camino.Insert(0, nodo);
                    nodo = padres[nodo];
                }
                return camino;
            }

            foreach (int vecino in grafo.ContainsKey(actual) ? grafo[actual] : new List<int>())
            {
                if (!padres.ContainsKey(vecino))
                {
                    pila.Push(vecino);
                    padres[vecino] = actual;
                }
            }
        }

        return new List<int>();
    }

    static string ObtenerNombresDepartamentos(Dictionary<int, string> nombresDepartamentos, List<int> camino)
    {
        List<string> nombres = new List<string>();
        foreach (int nodo in camino)
        {
            if (nombresDepartamentos.ContainsKey(nodo))
            {
                nombres.Add(nombresDepartamentos[nodo]);
            }
        }
        return string.Join(" -> ", nombres);
    }
}
