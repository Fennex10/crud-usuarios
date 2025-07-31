# Métodos CRUD en Repositorio.cs

## GetAll()
- Retorna: List<Usuario>  
- Query: SELECT Id, Nombre, Correo, Rol FROM Usuarios

## Add(Usuario usuario)
- Parámetros: usuario.Nombre, usuario.Correo, usuario.Rol  
- Query: INSERT INTO Usuarios (...) VALUES (...)
