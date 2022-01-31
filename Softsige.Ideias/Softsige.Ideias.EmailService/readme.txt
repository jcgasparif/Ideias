
Instando o servico cmd.exe (em modo adm)
--------------------------------------------------------
sc create Softsige.Ideias.EmailService BinPath="C:\[CAMINHO_DO_SERVICO]\Softsige.Ideias.EmailService.exe" DisplayName= "Tatu Marchesan Ideias Email Service" start=auto

Iniciado/Parando/Excluindo o servico
--------------------------------------------------------
sc start Softsige.Ideias.EmailService
sc stop Softsige.Ideias.EmailService
sc delete Softsige.Ideias.EmailService