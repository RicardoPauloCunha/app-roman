USE Roman;
GO

INSERT INTO TiposUsuarios
VALUES ('ADMINISTRADOR'),
('PROFESSOR');

INSERT INTO Usuarios
VALUES ('admin@admin.com', 'Administrador', 'admin123', 1),
('ricardo@gmail.com', 'Ricardo', 'ricardo123', 2);

INSERT INTO EQUIPES
VALUES('Desenvolvimento');

INSERT INTO PROFESSORES
VALUES(2, 1);

INSERT INTO TEMAS
VALUES('API', 0);

INSERT INTO PROJETOS
VALUES('SpMedGroup', 'Lista de personagens que serão consumido em uma api externa utilizando react Native', 1, 1);								