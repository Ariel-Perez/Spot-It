CREATE TABLE Usuario(
Id int IDENTITY(1,1),
Nombre nvarchar(60),
Apellido nvarchar(60),
Mail nvarchar(60),
Apodo nvarchar(60),
FechaRegistro datetime DEFAULT(getdate()),
NumComentarios int,
NumFotos int,
NumSugerenciasLugares int,
NumEventosCreados int,
NumEventosAsistidos int,
NumFavoritos int,
NumGenteInvitada int,
CONSTRAINT "Usuario_pkey" PRIMARY KEY(Id));

CREATE TABLE Facultad(
Id int IDENTITY(1,1),
Nombre nvarchar(100),
CONSTRAINT "Facultad_pkey" PRIMARY KEY(Id));

CREATE TABLE Lugar(
Id int IDENTITY(1,1),
Nombre nvarchar(100),
Descripcion ntext,
LugarId int,
FacultadId int,
CONSTRAINT "Lugar_pkey" PRIMARY KEY(Id),
CONSTRAINT "Lugar_fkey" FOREIGN KEY(LugarId) references Lugar(Id),
CONSTRAINT "Lugar_fkey2" FOREIGN KEY(FacultadId) references Facultad(Id));

CREATE TABLE Punto(
LugarId int,
NumPunto int,
X int,
Y int,
CONSTRAINT "Punto_pkey" PRIMARY KEY(LugarId, NumPunto),
CONSTRAINT "Punto_fkey" FOREIGN KEY(LugarId) references Lugar(Id));


CREATE TABLE Evento(
Id int IDENTITY(1,1),
Nombre nvarchar(100),
FechaInicio datetime,
FechaTermino datetime,
LinkFacebook nvarchar(200),
LugarId int,
X int,
Y int,
CONSTRAINT "Evento_pkey" PRIMARY KEY(Id),
CONSTRAINT "Evento_fkey" FOREIGN KEY(LugarId) references Lugar(Id));

CREATE TABLE Comentario(
LugarId int,
Numero int,
UsuarioId int,
Fecha datetime DEFAULT(getdate()),
Texto ntext,
CONSTRAINT "Comentario_pkey" PRIMARY KEY(LugarId, Numero),
CONSTRAINT "Comentario_fkey1" FOREIGN KEY(LugarId) references Lugar(Id),
CONSTRAINT "Comentario_fkey2" FOREIGN KEY(UsuarioId) references Usuario(Id));

CREATE TABLE Asiste(
EventoId int,
UsuarioId int,
Rating float,
CONSTRAINT "Asiste_pkey" PRIMARY KEY(EventoId, UsuarioId),
CONSTRAINT "Asiste_fkey1" FOREIGN KEY(EventoId) references Evento(Id),
CONSTRAINT "Asiste_fkey2" FOREIGN KEY(UsuarioId) references Usuario(Id));

CREATE TABLE Favorito(
LugarId int,
UsuarioId int,
Fecha datetime DEFAULT(getdate()),
CONSTRAINT "Favorito_pkey" PRIMARY KEY(LugarId, UsuarioId),
CONSTRAINT "Favorito_fkey1" FOREIGN KEY(LugarId) references Lugar(Id),
CONSTRAINT "Favorito_fkey2" FOREIGN KEY(UsuarioId) references Usuario(Id));

CREATE TABLE Medalla(
Id int IDENTITY(1,1),
Nombre nvarchar(60),
Imagen nvarchar(200),
NumComentarios int,
NumFotos int,
NumSugerenciasLugares int,
NumEventosCreados int,
NumEventosAsistidos int,
NumFavoritos int,
NumGenteInvitada int,
CONSTRAINT "Medalla_pkey" PRIMARY KEY(Id));

CREATE TABLE Premio(
UsuarioId int,
MedallaId int,
Fecha datetime DEFAULT(getdate()),
CONSTRAINT "Premio_pkey" PRIMARY KEY(UsuarioId, MedallaId),
CONSTRAINT "Premio_fkey1" FOREIGN KEY(UsuarioId) references Usuario(Id),
CONSTRAINT "Premio_fkey2" FOREIGN KEY(MedallaId) references Medalla(Id));

CREATE TABLE Categoria(
Id int Identity(1,1),
Nombre nvarchar(100),
CONSTRAINT "Categoria_pkey" PRIMARY KEY(Id));

CREATE TABLE LugarCategoria(
CategoriaId int,
LugarId int,
CONSTRAINT "LugarCategoria_pkey" PRIMARY KEY(CategoriaId, LugarId),
CONSTRAINT "LugarCategoria_fkey" FOREIGN KEY(CategoriaId) references Categoria(Id),
CONSTRAINT "LugarCategoria_fkey2" FOREIGN KEY(LugarId) references Lugar(Id));

CREATE TABLE Foto(
LugarId int,
Numero int,
Imagen nvarchar(200),
CONSTRAINT "Foto_pkey" PRIMARY KEY(LugarId, Numero),
CONSTRAINT "Foto_fkey" FOREIGN KEY(LugarId) references Lugar(Id));

CREATE TABLE Sala(
LugarId int,
Capacidad int,
CONSTRAINT "Sala_pkey" PRIMARY KEY(LugarId),
CONSTRAINT "Sala_fkey1" FOREIGN KEY(LugarId) references Lugar(Id));

CREATE TABLE Departamento(
Id int,
FacultadId int,
Nombre nvarchar(100),
CONSTRAINT "Departamento_pkey" PRIMARY KEY(Id, FacultadId),
CONSTRAINT "Departamento_fkey" FOREIGN KEY(FacultadId) references Facultad(Id));

CREATE TABLE Autoridad(
Id int IDENTITY(1, 1),
Nombre nvarchar(100),
Apellido nvarchar(100),
Mail nvarchar(100),
X int,
Y int,
CONSTRAINT "Autoridad_pkey" PRIMARY KEY(Id));

CREATE TABLE TrabajaEn(
FacultadId int,
AutoridadId int,
DepartamentoId int,
Cargo nvarchar(100),
CONSTRAINT "TrabajaEn_pkey" PRIMARY KEY(FacultadId, AutoridadId, DepartamentoId),
CONSTRAINT "TrabajaEn_fkey1" FOREIGN KEY(FacultadId) references Facultad(Id),
CONSTRAINT "TrabajaEn_fkey2" FOREIGN KEY(AutoridadId) references Autoridad(Id),
CONSTRAINT "TrabajaEn_fkey3" FOREIGN KEY(DepartamentoId, FacultadId) references Departamento(Id, FacultadId));

