# sql-api

Joachim Nilsson - gitlab.com/klutcharn
Thomas Annerfeldt - gitlab.com/thumas

# Setting up local SQL
In appsettings.json, set your local SQLEXPRESS here:
"DefaultConnection": "Data Source = **--HERE--**\\SQLEXPRESS; Initial Catalog = MoviesDb; Integrated Security = True"

# Franchise 1 : Uncategorized

We made the decision to make an "Uncategorized" franchise for movies that aren't a part of a franchise, so franchise ID is required when entering a movie

# Nullable attributes

Other than ID, Name/title and franchise ID and other FK ish elements, we decided to make everything nullable, so you can enter a movie temporarly while not knowing the director or having an URL available

# Commit history

We did a blunder halfway through the project and realized that a LOT of files that were not supposed to be there was not listed in the   gitignore, resulting in us moving all the files to a new repo. 





