#Creates a new battleship game that takes that arguments of rows, columns, and human/computer
def startBattleship(r,c,h):
	from random import randint
	
	#creates an empty board list used to create visual board
	board = []
	
	#gives the list the amount of columns in a row
	for x in range(r):		
		board.append(["O"] * c)
		
	#prints labels on sides and completes the rows for the board
	def print_board(board):
		y = 0
		print (" ", end = ' ')
		for i in range(c):
			print (y, end = ' ')
			y += 1
		print()
		y = 0
		for row in board:
			print(y, " ".join(row))
			y += 1
	print("Let's play Battleship!")
	
	#outputs total guesses
	print("You have", int((c*r)*.25), "Guesses.")
	
	#prints the board
	print_board(board)
	
	#defines a random ship placed somewhere on the board
	def random_row(board):
		return randint(0, len(board) - 1)
	def random_col(board):
		return randint(0, len(board[0]) - 1)
	ship_row = random_row(board)
	ship_col = random_col(board)
	print("(",ship_row, ",",ship_col,")")
	
	totalturns = int((c*r)*.25)
	#Gives the player a certain amount of turns based on board size
	for turn in range(totalturns):
		#checks if row input should be user or human
		if h == "human":
			guess_row = int(input("Guess Row:"))
			guess_col = int(input("Guess Col:"))
		elif h == "computer":
			#for turn in range(int((c*r)*.25)):
			guess_row = randint(0,r-1)
			guess_col = randint(0,c-1)
			print("(",guess_row, ",",guess_col,")")
			
		#checks for victory
		if guess_row == ship_row and guess_col == ship_col:
			print("Congratulations! You sunk the battleship!")
			print()
			guessesleft = (c-2) - turn
			break
		
		#checks for incorrect guess
		else:		
			
			#if guess is outside of range of table the user must guess again
			while (guess_row < 0 or guess_row > r-1) or (guess_col < 0 or guess_col > c-1):
				print("Oops, that's not even in the ocean.")
				if h == "human":
					guess_row = int(input("Guess Row:"))
					guess_col = int(input("Guess Col:"))
			#if guess has already been guessed the user must guess again
			while(board[guess_row][guess_col] == "X"):
				print("You guessed that one already.")
				if h == "human":
					guess_row = int(input("Guess Row:"))
					guess_col = int(input("Guess Col:"))
					while (guess_row < 0 or guess_row > r-1) or (guess_col < 0 or guess_col > c-1):
						print("Oops, that's not even in the ocean.")
						if h == "human":
							guess_row = int(input("Guess Row:"))
							guess_col = int(input("Guess Col:"))
				elif h == "computer":
					guess_row = randint(0,r-1)
					guess_col = randint(0,c-1)
					print("(",guess_row, ",",guess_col,")")
					
			#checks if guess missed and then places an X where the miss occured
			else:
				print("You missed my battleship!")
				print()
				board[guess_row][guess_col] = "X"
			#ranges equal each other to print game over
			if turn == (totalturns-1):
				print("Game Over")
		#outputs the total guesses left
		guessesleft = (totalturns - turn)
		print("Turn", turn + 1, "(Guesses Left:", guessesleft - 1, ")")
		#prints board after each guess
		print_board(board)
		print()
	return turn
def main():
	from random import randint
	h = "human"
	c = "computer"
	#player or computer input
	PorC = input("Would you like to play against the computer? (y/n):")
	
	#if user choose computer then computer sequence begins
	if PorC == "y":
		rows = randint(4,10)
		columns = randint(4,10)
		print("Human Player")
		t = startBattleship(rows, columns, h)
		print("Computer Player")
		t2 = startBattleship(rows, columns, c)
		#checks to see which user guessed the ship in the least amount of turns
		if t < t2:
			print("Human total turns", t + 1)
			print("Computer total turns", t2 + 1)
			print("Human Wins")
		elif t2 < t:
			print("Human total turns", t + 1)
			print("Computer total turns", t2 + 1)
			print("Computer Wins")
		else:
			print("The players tied")
	#starts the user controlled sequence with 1 or 2 players
	elif PorC == "n":
		players = int(input("would you like to play with 1 or 2 players?:"))
		if players == 1:
			rows = int(input("How many rows would you like between (4,10)?"))
			columns = int(input("How many columns would you like between (4,10)?"))
			if (rows >= 4 and rows <= 10) and (columns >= 4 and columns <= 10):
				startBattleship(rows,columns, h)
			else:
				print("Incorrect amount of rows or columns. Please try again")
				main()
		#calls the startBattleship twice since there are two players
		elif players == 2:
			rows = int(input("How many rows would you like between (4,10)?"))
			columns = int(input("How many columns would you like between (4,10)?"))
			if (rows >= 4 and rows <= 10) and (columns >= 4 and columns <= 10):
				print("player 1")
				t = startBattleship(rows,columns, h)
				print("Player 2")
				t2 = startBattleship(rows, columns, h)
				#Checks to see who won
				if t < t2:
					print("player 1 total turns", t + 1)
					print("Player 2 total turns", t2 + 1)
					print("Player 1 Wins")
				elif t2 < t:
					print("player 1 total turns", t + 1)
					print("Player 2 total turns", t2 + 1)
					print("Player 2 Wins")
				else:
					print("The players tied")
			else:
				print("Incorrect amount of rows or columns. Please try again")
				main()
		else:
			print("incorrect amount of players")
			main()
	else:
		print("invalid input")
		main()
main()
