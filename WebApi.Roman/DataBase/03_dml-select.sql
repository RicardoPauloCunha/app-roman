USE Roman;
GO

SELECT U.Id, U.Email, U.Nome, T.Descricao, U.Senha FROM Usuarios U 
JOIN TiposUsuarios T 
ON U.TipoUsuarioId = T.Id;

SELECT * FROM Usuarios;
SELECT * FROM TiposUsuarios;
SELECT * FROM Temas;
SELECT * FROM Projetos;
SELECT * FROM Professores;
SELECT * FROM Equipes;

SELECT P.Id, U.Nome, E.Descricao FROM Professores P 
JOIN Usuarios U
ON U.Id = P.UsuariosId
JOIN Equipes E
ON E.Descricao = 'Desenvolvimento';