import socket
import random

port = 10101
server = socket.socket()
server.bind(('', port))
server.listen(1)

print("Server started at port", port)

client, ip = server.accept()

print("Client connected:", ip)

while True:
    data = client.recv(256)
    if (not data):
        break

    s = data.decode('utf-8')

    if s == 'exit':
        break

    if s == 'yaw':
        d = random.randint(-10,10)
        client.send(str(d).encode('utf-8'))

client.close()