using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            actualizar_salas();//metodo que busca informacion de las salas desde el portal de la dara, parsea los datos y los ingresa a la base de datos


        }
        public static void actualizar_salas()//método que actualiza la tabla horarios si se debe hacer, se hace como minimo cada semana 
        {

            string url = "http://www7.uc.cl/dara/registro/serviciosprof/salas_campus/salacampus_2_semana01.html";//url a extraer info para la tablña horarios
            string pagina = getPageSource(url);//llama almetodo que obtiene el string con el html de la url
            if (dayOfWeek())//si se debe hacer la actualizacion
            {
                ArrayList sala = new ArrayList();//guarda salas
                ArrayList dia = new ArrayList();//guarda el horario en el cierto dia (ej :L1 significa Lunes modulo 1,M4 = martes 4 modulo, W6 = miercoles modulo 6
                ArrayList modulo = new ArrayList();
                ArrayList curso = new ArrayList();//guarda el curso dictado
                ArrayList tipo_actividad = new ArrayList();//guarda el tipo de actividad que se esta haciendo (ej: cat=catedra)
                getinfo(pagina, sala, dia, modulo, curso, tipo_actividad);//llama al metodo que hace el parse entre el string html y los arraylist
                limpiar();
                for (int i = 0; sala.Count > i; i++)//recorremos los arraylist
                {
                    actualizar(sala[i].ToString(), dia[i].ToString(), Convert.ToInt32(modulo[i].ToString()),curso[i].ToString(), tipo_actividad[i].ToString());
                }
                Console.WriteLine("termino");
            }

        }

        public static bool actualizar(string sala,string dia,int modulo,string curso,string tipo_actividad)
        {
            //creamos la conexion con la BD
            string cadenConexion = "workstation id=ingenieria.mssql.somee.com;packet size=4096;user id=grupo8_SQLLogin_1;pwd=pz3vzt3b6t;data source=ingenieria.mssql.somee.com;persist security info=False;initial catalog=ingenieria";
            //generamos el objeto de conexion
            SqlConnection conexionBD = new SqlConnection(cadenConexion);
            conexionBD.Open();//abrimos la conexion

            int LugarId=id_lugar(sala);
            String Consulta = "Insert Into Horario(LugarId,Dia,Modulo,curso,tipo_actividad,fecha_ingreso) values(@LugarId, @Dia,@Modulo, @curso,@tipo_actividad,@fecha_ingreso)";//obtiene la ultima fila en horarios
            
            SqlCommand Orden = new SqlCommand(Consulta, conexionBD);//creamos el comando sql
            Orden.Parameters.Add("@Lugarid", SqlDbType.NVarChar).Value = LugarId;
            Orden.Parameters.Add("@Dia", SqlDbType.NVarChar).Value = dia;
            Orden.Parameters.Add("@Modulo", SqlDbType.Int).Value = modulo;
            Orden.Parameters.Add("@curso", SqlDbType.NVarChar).Value = curso;
            Orden.Parameters.Add("@tipo_actividad", SqlDbType.NVarChar).Value = tipo_actividad;
            Orden.Parameters.Add("@fecha_ingreso", SqlDbType.DateTime).Value = DateTime.Now;
            try
            {
                int rows = Orden.ExecuteNonQuery();//ejecutamos la query de insercion
                Console.WriteLine("Insert Into Horario("+LugarId+","+dia+","+modulo+","+curso+","+tipo_actividad+","+DateTime.Now+") ==="+rows);
                return true;
            }
            finally
            {
                // cerramos la conexion
                conexionBD.Close();
            }
            return false;
        }
        public static void limpiar()
        {
            //creamos la conexion con la BD
            string cadenConexion = "workstation id=ingenieria.mssql.somee.com;packet size=4096;user id=grupo8_SQLLogin_1;pwd=pz3vzt3b6t;data source=ingenieria.mssql.somee.com;persist security info=False;initial catalog=ingenieria";
            //generamos el objeto de conexion
            SqlConnection conexionBD = new SqlConnection(cadenConexion);
            conexionBD.Open();//abrimos la conexion

            //creamos una consulta
            string Consulta = "delete Horario";//obtiene la ultima fila en horarios
            SqlCommand Orden1 = new SqlCommand(Consulta, conexionBD);//creamos el comando sql
            int rows=Orden1.ExecuteNonQuery();
            Console.WriteLine("deleted rows = " + rows);
        }
        public static int id_lugar(string sala)
        {
            //creamos la conexion con la BD
            string cadenConexion = "workstation id=ingenieria.mssql.somee.com;packet size=4096;user id=grupo8_SQLLogin_1;pwd=pz3vzt3b6t;data source=ingenieria.mssql.somee.com;persist security info=False;initial catalog=ingenieria";
            //generamos el objeto de conexion
            SqlConnection conexionBD = new SqlConnection(cadenConexion);
            conexionBD.Open();//abrimos la conexion


            string Consulta = "SELECT Id from Lugar where nombre='"+sala+"'";//obtiene la ultima fila en horarios
            SqlCommand Orden = new SqlCommand(Consulta, conexionBD);//creamos el comando sql
            SqlDataReader reader = Orden.ExecuteReader();//ejecutamos el comando en un sqldatareader, toda la info queda en reader
            int id = -1;
            try
            {
                while (reader.Read())//si reader contiene datos
                {
                    id=reader.GetInt32(0);
                }
            }
            finally
            {
                // cerramos el reader y la conexion
                reader.Close();
                conexionBD.Close();
            }
            return id;
        }

        public static bool dayOfWeek()//metodo que verifica que la actualizacion de la tabla se haga solo una vez en la semana
        {
            //creamos la conexion con la BD
            string cadenConexion = "workstation id=ingenieria.mssql.somee.com;packet size=4096;user id=grupo8_SQLLogin_1;pwd=pz3vzt3b6t;data source=ingenieria.mssql.somee.com;persist security info=False;initial catalog=ingenieria";
            //generamos el objeto de conexion
            SqlConnection conexionBD = new SqlConnection(cadenConexion);
            conexionBD.Open();//abrimos la conexion

            //creamos una consulta
            string Consulta = "SELECT max(fecha_ingreso) from Horario";//obtiene la ultima fila en horarios
            SqlCommand Orden = new SqlCommand(Consulta, conexionBD);//creamos el comando sql
            SqlDataReader reader = Orden.ExecuteReader();//ejecutamos el comando en un sqldatareader, toda la info queda en reader
            try
            {
                while (reader.Read())//si reader contiene datos
                {
                    DateTime fecha_actual = DateTime.Now;//obtiene fecha actual
                    DateTime fecha_anterior = reader.GetDateTime(0);//obtiene como date la fecha guardada en la base de datos
                    string dia = fecha_anterior.DayOfWeek.ToString();//obtiene el dia y lo convierte en string
                    Console.WriteLine("fecha ultima actualizacion = " + fecha_anterior);
                    //compara que dia de la semana es , le agrega lo que falta para llegar al lunes 
                    if (dia.Equals("Monday"))
                       fecha_anterior= fecha_anterior.AddDays(7);
                    else if (dia.Equals("Tuesday"))
                        fecha_anterior = fecha_anterior.AddDays(6);
                    else if (dia.Equals("Wednesday"))
                        fecha_anterior = fecha_anterior.AddDays(5);
                    else if(dia.Equals("Thursday"))
                        fecha_anterior = fecha_anterior.AddDays(4);
                    else if (dia.Equals("Friday"))
                        fecha_anterior = fecha_anterior.AddDays(3);
                    else if (dia.Equals("Saturday"))
                        fecha_anterior = fecha_anterior.AddDays(2);
                    else if (dia.Equals("Sunday"))
                        fecha_anterior = fecha_anterior.AddDays(1);
                    if (fecha_actual.CompareTo(fecha_anterior) >= 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            finally
            {
                // cerramos el reader y la conexion
                reader.Close();
                conexionBD.Close();
            }
            return false;
        }
        
        static string getPageSource(string URL)//se conecta a la pagina indicada y devuelve un string con el html
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            string strSource = webClient.DownloadString(URL);
            webClient.Dispose();
            return strSource;
        }

        static void getinfo(string pag, ArrayList sala,ArrayList dia,ArrayList modulo, 
                                ArrayList curso, ArrayList tipo_actividad)//desde el string on el html,parsea los valores buscados en los 4 arraylist 
                                                                          //si algun valor esta vacio, o significa queno hay nada coloca un -
        {
            string[] lineas= pag.Split(new string[] { "<a" }, StringSplitOptions.RemoveEmptyEntries);//se separa el string del html
            for (int i = 0; i < lineas.Length;i++)//iteramos en cada linea
            {
                if (lineas[i].Contains("title=\""))//buscamos el atributo que contiene la sala
                {
                    int largo = lineas[i].IndexOf("\" OnMouseOver") - indice(lineas[i]);//obtiene el largo del substring del codigo de sala+horario
                    string aux = lineas[i].Substring(indice(lineas[i]), largo);//obtiene el string de codigo de la sala+horario
                    largo = lineas[i].IndexOf("<") - indice2(lineas[i])+1;//obtiene el largo del codigo del curso+tipo_actividad(catedra, ayudantia,etc)
                    string aux2 = lineas[i].Substring(indice2(lineas[i]), largo-1);//obtiene el string curso+tipo_actividad

                    string[] a = aux.Split('-',';');//separa sala y horario
                    string[] b = aux2.Split(',',';');//separa curso y tipo_actividad

                    if (a[0].Contains("FT"))//caso especial de las salas de teologia
                    {
                        a[0] = a[0] + a[1];
                        a[1] = a[2];
                    }

                    sala.Add(a[0]);//se añade la sala al arraylist 
                    a[1] = a[1].Substring(0, 2);
                    modulo.Add(Convert.ToInt32(a[1].Substring(1)));
                    if (a[1].Contains("L"))
                        a[1] = "Lunes";
                    else if (a[1].Contains("M"))
                        a[1] = "Martes";
                    else if (a[1].Contains("W"))
                        a[1] = "Miercoles";
                    else if (a[1].Contains("J"))
                        a[1] = "Jueves";
                    else if (a[1].Contains("V"))
                        a[1] = "Viernes";
                    else if (a[1].Contains("S"))
                        a[1] = "Sabado";
                    dia.Add(a[1]);//se añade el horario al arraylist
                    
                    if (!b[0].Contains("xxxxxxxxx"))//verificamos que el horario no signifique vacio
                    {
                        if (b[0].Contains("\n"))
                            b[0] = b[0].Substring(1);
                        curso.Add(b[0]);//se añade el curso al arraylist
                        //se verifica que exista la actividad
                        if (b.Length > 1)
                            tipo_actividad.Add(b[1]);
                        else
                            tipo_actividad.Add(" - ");
                    }
                    else // si no hay uso de esa sala en el horario indicado se rellena curso y tipo_actividad con - 
                    {
                        curso.Add(" - ");
                        tipo_actividad.Add(" - ");
                    }

                }
            }
        }
        static int indice(string a)//obtiene el indice de una subcadena con title="
        {
            int aux=a.IndexOf("title=\"");
            aux += 7;
            return aux;
        }
        static int indice2(string a)//obtiene el indice de una subcadena > 
        {
            int aux = a.IndexOf(">");
            aux += 1;
            return aux;
        }

    }
}
