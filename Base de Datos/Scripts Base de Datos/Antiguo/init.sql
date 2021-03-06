CREATE TABLE Usuario(
id int IDENTITY(1,1),
nombre nvarchar(60),
apellido nvarchar(60),
mail nvarchar(60),
apodo nvarchar(60),
fecha_registro datetime DEFAULT(getdate()),
numComentarios int,
numFotos int,
numSugerenciasLugares int,
numEventosCreados int,
numEventosAsistidos int,
numFavoritos int,
numGenteInvitada int,
CONSTRAINT "Usuario_pkey" PRIMARY KEY(id));

CREATE TABLE Mapa(
id int IDENTITY(1,1),
nombre nvarchar(60),
imagen varbinary(5000),
fecha_creacion datetime DEFAULT(getdate()),
CONSTRAINT "Mapa_pkey" PRIMARY KEY(id));

CREATE TABLE Zona(
idMapa int,
id int IDENTITY(1,1),
nombre nvarchar(100),
fecha_creacion datetime DEFAULT(getdate()),
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
descripcion ntext,
CONSTRAINT "Lugar_pkey" PRIMARY KEY(idMapa, idZona),
CONSTRAINT "Lugar_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Evento(
idMapa int,
idZona int,
nombre nvarchar(100),
fecha_inicio datetime,
fecha_termino datetime,
link nvarchar(1024),
CONSTRAINT "Evento_pkey" PRIMARY KEY(idMapa, idZona, nombre, fecha_inicio),
CONSTRAINT "Evento_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Comentario(
idMapa int,
idZona int,
idUsuario int,
id int,
fecha datetime DEFAULT(getdate()),
texto ntext,
CONSTRAINT "Comentario_pkey" PRIMARY KEY(idMapa, idZona, idUsuario, id),
CONSTRAINT "Comentario_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id),
CONSTRAINT "Comentario_fkey2" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Asiste(
idMapa int,
idZona int,
nombreEvento nvarchar(100),
fecha datetime,
idUsuario int,
rating float,
CONSTRAINT "Asiste_pkey" PRIMARY KEY(idMapa, idZona, nombreEvento, fecha, idUsuario),
CONSTRAINT "Asiste_fkey1" FOREIGN KEY(idMapa, idZona, nombreEvento, fecha) references Evento(idMapa, idZona, nombre, fecha_inicio),
CONSTRAINT "Asiste_fkey2" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Sugerencia_Lugar(
idMapa int,
nombre nvarchar(100),
idUsuario int,
x int,
y int,
fecha_creacion datetime DEFAULT(getdate()),
texto ntext,
CONSTRAINT "Sugerencia_Lugar_pkey" PRIMARY KEY(idMapa, nombre, idUsuario),
CONSTRAINT "Sugerencia_Lugar_fk21" FOREIGN KEY(idMapa) references Mapa(id),
CONSTRAINT "Sugerencia_Lugar_fk22" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Favorito(
idMapa int,
idZona int,
idUsuario int,
fecha datetime DEFAULT(getdate()),
CONSTRAINT "Favorito_pkey" PRIMARY KEY(idMapa, idZona, idUsuario),
CONSTRAINT "Favorito_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id),
CONSTRAINT "Favorito_fkey3" FOREIGN KEY(idUsuario) references Usuario(id));

CREATE TABLE Badge(
nombre nvarchar(60),
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
nombreMedalla nvarchar(60),
fecha datetime DEFAULT(getdate()),
CONSTRAINT "Premio_pkey" PRIMARY KEY(idUsuario, nombreMedalla),
CONSTRAINT "Premio_fkey1" FOREIGN KEY(idUsuario) references Usuario(id),
CONSTRAINT "Premio_fkey2" FOREIGN KEY(nombreMedalla) references Badge(nombre));

CREATE TABLE Categoria(
nombre nvarchar(100),
CONSTRAINT "Categoria_pkey" PRIMARY KEY(nombre));

CREATE TABLE Lugar_En_Categoria(
idMapa int,
idZona int,
nombreCategoria nvarchar(100),
CONSTRAINT "Lugar_En_Categoria_pkey" PRIMARY KEY(idMapa, idZona, nombreCategoria),
CONSTRAINT "Lugar_En_Categoria_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Foto(
idMapa int,
idZona int,
id int IDENTITY(1,1),
foto varbinary(5000),
CONSTRAINT "Foto_pkey" PRIMARY KEY(idMapa, idZona, id),
CONSTRAINT "Foto_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Complejo(
idMapa int,
idZona int,
codigo nvarchar(60),
CONSTRAINT "Complejo_pkey" PRIMARY KEY(idMapa, codigo),
CONSTRAINT "Complejo_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Sala(
idMapa int,
idZona int,
codigoComplejo nvarchar(60),
codigo nvarchar(60),
capacidad int,
CONSTRAINT "Sala_pkey" PRIMARY KEY(idMapa, codigo),
CONSTRAINT "Sala_fkey1" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id),
CONSTRAINT "Sala_fkey2" FOREIGN KEY(idMapa, codigoComplejo) references Complejo(idMapa, codigo));

CREATE TABLE Facultad(
idMapa int,
idZona int,
nombre nvarchar(100),
CONSTRAINT "Facultad_pkey" PRIMARY KEY(idMapa, nombre),
CONSTRAINT "Facultad_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE Departamento(
idMapa int,
nombreFacultad nvarchar(100),
nombre nvarchar(100),
CONSTRAINT "Departamento_pkey" PRIMARY KEY(idMapa, nombreFacultad, nombre),
CONSTRAINT "Departamento_fkey" FOREIGN KEY(idMapa, nombreFacultad) references Facultad(idMapa, nombre));

CREATE TABLE Autoridad(
idMapa int,
id int IDENTITY(1, 1),
idZona int,
nombre nvarchar(100),
apellido nvarchar(100),
mail nvarchar(100),
CONSTRAINT "Autoridad_pkey" PRIMARY KEY(idMapa, id),
CONSTRAINT "Autoridad_fkey" FOREIGN KEY(idMapa, idZona) references Zona(idMapa, id));

CREATE TABLE TrabajaEn(
idMapa int,
nombreFacultad nvarchar(100),
nombreDepto nvarchar(100),
idAutoridad int,
cargo nvarchar(100),
CONSTRAINT "TrabajaEn_pkey" PRIMARY KEY(idMapa, nombreFacultad, nombreDepto, idAutoridad),
CONSTRAINT "TrabajaEn_fkey1" FOREIGN KEY(idMapa, nombreFacultad) references Facultad(idMapa, nombre),
CONSTRAINT "TrabajaEn_fkey2" FOREIGN KEY(idMapa, nombreFacultad, nombreDepto) references Departamento(idMapa, nombreFacultad, nombre),
CONSTRAINT "TrabajaEn_fkey3" FOREIGN KEY(idMapa, idAutoridad) references Autoridad(idMapa, id));

