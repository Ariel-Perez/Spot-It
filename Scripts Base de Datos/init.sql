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
CONSTRAINT "Zona_fkey" FOREIGN KEY(idMapa) references Mapa(id));

CREATE TABLE Punto(
idMapa int,
idZona int,
numPunto int, 
x int,
y int,
CONSTRAINT "Punto_pkey" PRIMARY KEY(idMapa, idZona, numPunto),
CONSTRAINT "Punto_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Construccion(
idMapa int,
idZona int,
fecha_termino datetime,
CONSTRAINT "Construccion_pkey" PRIMARY KEY(idMapa, idZona),
CONSTRAINT "Construccion_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Lugar(
idMapa int,
idZona int,
descripcion text,
CONSTRAINT "Lugar_pkey" PRIMARY KEY(idMapa, idZona),
CONSTRAINT "Lugar_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Evento(
idMapa int,
idZona int,
nombre varchar(100),
fecha_inicio datetime,
fecha_termino datetime,
link text,
CONSTRAINT "Evento_pkey" PRIMARY KEY(idMapa, idZona, nombre, fecha_inicio),
CONSTRAINT "Evento_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Comentario(
idMapa int,
idZona int,
idUsuario int,
id int,
fecha datetime,
texto text,
CONSTRAINT "Comentario_pkey" PRIMARY KEY(idMapa, idZona, idUsuario, id),
CONSTRAINT "Comentario_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id),
CONSTRAINT "Comentario_fkey2" FOREIGN KEY(idUsuario) references a Usuario(id));

CREATE TABLE Asiste(
idMapa int,
idZona int,
nombreEvento varchar(100),
fecha datetime,
idUsuario int,
rating float8,
CONSTRAINT "Asiste_pkey" PRIMARY KEY(idMapa, idZona, nombreEvento, fecha, idUsuario),
CONSTRAINT "Asiste_fkey1" FOREIGN KEY(idMapa, idZona, nombreEvento, fecha) references Evento(idMapa, idZona, nombre, fecha_inicio),
CONSTRAINT "Asiste_fkey2" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Sugerencia_Lugar(
idMapa int,
nombre varchar(100),
idUsuario int,
x int,
y int,
fecha_creacion datetime,
texto text,
CONSTRAINT "Sugerencia_Lugar_pkey" PRIMARY KEY(idMapa, nombre, idUsuario),
CONSTRAINT "Sugerencia_Lugar_fk21" FOREIGN KEY(idMapa) references Mapa(id),
CONSTRAINT "Sugerencia_Lugar_fk22" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Favorito(
idMapa int,
idZona int,
idUsuario int,
fecha datetime,
CONSTRAINT "Favorito_pkey" PRIMARY KEY(idMapa, idZona, idUsuario),
CONSTRAINT "Favorito_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id),
CONSTRAINT "Favorito_fkey3" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Badge(
nombre varchar(60),
imagen varbinary(1024),
numComentarios int,
numFotos int,
numSugerenciasLugares int,
numEventosCreados int,
numEventosAsistidos int,
numFavoritos int,
numGenteInvitada int,
CONSTRAINT "Badge_pkey" PRIMARY KEY(nombre));

CREATE TABLE Premio(
idUsuario int,
nombreMedalla varchar(60),
fecha datetime,
CONSTRAINT "Premio_pkey" PRIMARY KEY(idUsuario, nombreMedalla),
CONSTRAINT "Premio_fkey1" FOREIGN KEY(idUsuario) references Badge(nombre));

CREATE TABLE Categoria(
nombre varchar(100),
CONSTRAINT "Categoria_pkey" PRIMARY KEY(nombre));

CREATE TABLE Lugar_En_Categoria(
idMapa int,
idZona int,
nombreCategoria varchar(100),
CONSTRAINT "Lugar_En_Categoria_pkey" PRIMARY KEY(idMapa, idZona, nombreCategoria),
CONSTRAINT "Lugar_En_Categoria_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Foto(
idMapa int,
idZona int,
id int,
foto varbinary(5000),
CONSTRAINT "Foto_pkey" PRIMARY KEY(idMapa, idZona, id),
CONSTRAINT "Foto_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

