USE Roman;
GO

INSERT INTO TIPO_USUARIOS VALUES ('ADMINISTRADOR'),
('PROFESSOR');
GO

INSERT INTO USUARIOS VALUES ('admin@admin.com', 'Administrador', 'admin123', 1),
('ricardo@gmail.com', 'Ricardo', 'ricardo123', 2);
GO

INSERT INTO EQUIPES VALUES('Desenvolvimento');
GO

INSERT INTO PROFESSORES VALUES(2, 1);
GO

INSERT INTO TEMAS VALUES('API', 0);
GO

INSERT INTO PROJETOS VALUES('SpMedGroup', 'Lista de personagens que serão consumido em uma api externa utilizando react Native', 1, 1);
GO




								