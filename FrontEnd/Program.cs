using FrontEnd;

HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7180/")
};

Sistema sistema = new Sistema(cliente);
sistema.InicializarSistema();