CREATE TABLE Usuario(
id int,
nombre varchar(60),
apellido varchar(60),
mail varchar(60),
numComentarios int,
numFotos int,
numSugerenciasLugares int,
numEventosCreados int,
numEventosAsistidos int
numFavoritos int,
numGenteInvitada int,
CONSTRAINT "Usuario_pkey" PRIMARY KEY(id));

CREATE TABLE Mapa(
id int,
nombre varchar(60),
imagen varbinary(5000),
fecha_creacion datetime,
CONSTRAINT "Mapa_pkey" PRIMARY KEY(id));

CREATE TABLE Zona(
idMapa int,
id int,
nombre varchar(100),
fecha_creacion datetime,
CONSTRAINT "Zona_pkey" PRIMARY KEY(idMapa, id),
CONSTRAINT "Zona_fkey" FOREIGN KEY(idMapa) references Mapa.id;

CREATE TABLE Punto(
idMapa int,
idZona int,
numPunto int, 
x int,
y int,
CONSTRAINT "Punto_pkey" PRIMARY KEY(idMapa, idZona, numPunto),
CONSTRAINT "Punto_fkey1" FOREIGN KEY(idMapa) references Mapa.id,
CONSTRAINT "Punto_fkey2" FOREIGN KEY(idZona) references Zona.id;

CREATE TABLE Construccion(
idMapa int,
idZona int,
fecha_termino datetime,
CONSTRAINT "Construccion_pkey" PRIMARY KEY(idMapa, idZona),
CONSTRAINT "Construccion_fkey1" FOREIGN KEY(idMapa) references Mapa.id,
CONSTRAINT "Construccion_fkey2" FOREIGN KEY(idZona) references Zona.id;

CREATE TABLE Lugar(
idMapa int,
idZona int,
descripcion text,
CONSTRAINT "Lugar_pkey" PRIMARY KEY(idMapa, idZona),
CONSTRAINT "Lugar_fkey1" FOREIGN KEY(idMapa) references Mapa.id,
CONSTRAINT "Lugar_fkey2" FOREIGN KEY(idZona) references Zona.id;

CREATE TABLE Evento(
idMapa int,
idZona int,
nombre varchar(100),
fecha_inicio datetime,
fecha_termino datetime,
link text,
CONSTRAINT "Evento_pkey" PRIMARY KEY(idMapa, idZona, nombre, fecha_inicio),
CONSTRAINT "Evento_fkey1" FOREIGN KEY(idMapa) references Mapa.id,
CONSTRAINT "Evento_fkey2" FOREIGN KEY(idZona) references Zona.id;

CREATE TABLE Comentario(
idMapa int,
idZona int,
idUsuario int,
id int,
fecha datetime,
texto text,
CONSTRAINT "Comentario_pkey" PRIMARY KEY(idMapa, idZona, idUsuario, id),
CONSTRAINT "Comentario_fkey1" FOREIGN KEY(idMapa) references Mapa.id,
CONSTRAINT "Comentario_fkey2" FOREIGN KEY(idZona) references Zona.id,
CONSTRAINT "Comentario_fkey3" FOREIGN KEY(idUsuario) references a Usuario.id;

CREATE TABLE Asiste(
idMapa int,
idZona int,
nombreEvento varchar(100),
fecha datetime,
idUsuario int,
rating float8,
CONSTRAINT "Asiste_pkey" PRIMARY KEY(idMapa, idZona, nombreEvento, fecha, idUsuario);
CONSTRAINT "Asiste_fkey1" FOREIGN KEY(idMapa) references Mapa.id;
CONSTRAINT "Comentario_fkey2" FOREIGN KEY(idZona) references Zona.id;
CONSTRAINT "Comentario_fkey3" FOREIGN KEY(nombreEvento) references Evento.nombre,
CONSTRAINT "Comentario_fkey4" FOREIGN KEY(fecha) references Evento.fecha_inicio,
CONSTRAINT "Comentario_fkey5" FOREIGN KEY(idUsuario) references Usuario.id;





