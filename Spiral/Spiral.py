import turtle
pen = turtle.Turtle()
window = turtle.Screen()
i = 0
#CONFIG
darkMode = False
delta = 150
partLength = 500
spiralTurnAngle = 90
pen.speed(100)
#PROGRAM
pen.up()
pen.goto(-250,250)
pen.left(spiralTurnAngle)
if(darkMode):
    window.bgcolor("black")
    pen.color("white")
#ALGORITHM
pen.down()
while((partLength - delta * i) > 0):
    # top horizontal
    pen.right(spiralTurnAngle)
    pen.forward(partLength - delta * i)
    if(i != 0):
        i += 1
    if(delta * i >= partLength):
        break
    # vertical long
    pen.right(spiralTurnAngle)
    pen.forward(partLength - delta * i)
    # bottom horizontal
    pen.right(spiralTurnAngle)
    pen.forward(partLength - delta * i)
    # vertical short
    i += 1
    if(delta * i >= partLength):
        break
    pen.right(spiralTurnAngle)
    pen.forward(partLength - delta * i)
turtle.done()