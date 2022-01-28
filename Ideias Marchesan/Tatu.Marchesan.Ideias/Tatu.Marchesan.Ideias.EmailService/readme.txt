
Instando o servico cmd.exe (em modo adm)
--------------------------------------------------------
sc create Tatu.Marchesan.Ideias.EmailService BinPath="C:\[CAMINHO_DO_SERVICO]\Tatu.Marchesan.Ideias.EmailService.exe" DisplayName= "Tatu Marchesan Ideias Email Service" start=auto

Iniciado/Parando/Excluindo o servico
--------------------------------------------------------
sc start Tatu.Marchesan.Ideias.EmailService
sc stop Tatu.Marchesan.Ideias.EmailService
sc delete Tatu.Marchesan.Ideias.EmailService