1. Generate Self Signed CERTIFICATE

openssl req -newkey rsa:2048 -nodes -keyout eclatech.key-x509 -days 365 -out eclatech.crt

2. Adding UI

https://github.com/IdentityServer/IdentityServer4.Quickstart.UI/tree/main

curl -L https://raw.githubusercontent.com/IdentityServer/IdentityServer4.Quickstart.UI/main/getmain.sh | bash


https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4