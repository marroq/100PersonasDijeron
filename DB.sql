CREATE TABLE Pregunta ( 
	PreguntaId int,
	Descripcion varchar(200),
	PRIMARY KEY(PreguntaId)
);

CREATE TABLE Respuestas ( 
	PreguntaId int,
	RespuestaId int,
	Descripcion varchar(200),
	Puntaje int,
	FOREIGN KEY(PreguntaId) REFERENCES Pregunta(PreguntaId),
	PRIMARY KEY(PreguntaId,RespuestaId)
);
