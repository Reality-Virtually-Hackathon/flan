import pandas as pd
from scipy.spatial.distance import cosine

# --- Read Data --- #
data = pd.read_csv('encoded_x.csv')
print (data)
# --- Start Item Based Recommendations --- #
# Drop any column named "user"


# Create a placeholder dataframe listing item vs. item
data_ibs = pd.DataFrame(index=data.columns,columns=data.columns)

# Lets fill in those empty spaces with cosine similarities
# Loop through the columns
for i in range(0,len(data_ibs.columns)) :
    # Loop through the columns for each column
    for j in range(0,len(data_ibs.columns)) :
      # Fill in placeholder with cosine similarities
      data_ibs.ix[i,j] = 1-cosine(data.ix[:,i],data.ix[:,j])

# Create a placeholder items for closes neighbours to an item
data_neighbours = pd.DataFrame(index=data_ibs.columns,columns=[range(1,11)])

# Loop through our similarity dataframe and fill in neighbouring item names
for i in range(0,len(data_ibs.columns)):
    data_neighbours.ix[i,:8] = data_ibs.ix[0:,i][:8].index

# --- End Item Based Recommendations --- #

# --- Start User Based Recommendations --- #

# Helper function to get similarity scores
def getScore(history, similarities):
   return sum(history*similarities)/sum(similarities)

# Create a place holder matrix for similarities, and fill in the user name column
data_sims = pd.DataFrame(index=data.index,columns=data.columns)
data_sims.ix[:,:1] = data.ix[:,:1]

#Loop through all rows, skip the user column, and fill with similarity scores
for i in range(0,len(data_sims.index)):
    for j in range(1,len(data_sims.columns)):
        user = data_sims.index[i]
        product = data_sims.columns[j]

        if data.ix[i][j] == 1:
            data_sims.ix[i][j] = 0
        else:
            product_top_names = data_neighbours.ix[product][1:10]
            product_top_sims = data_ibs.ix[product][1:10]
            user_purchases = data.ix[user,product_top_names]

            data_sims.ix[i][j] = getScore(user_purchases,product_top_sims)

# Get the top songs
data_recommend = pd.DataFrame(index=data_sims.index)
data_recommend.ix[0:,0] = data_sims.ix[:,0]

# Instead of top song scores, we want to see names
for i in range(0,len(data_sims.index)):
    data_recommend.ix[i,1:] = data_sims.ix[i,:].order(ascending=False).ix[1:7,].index.transpose()

# Print a sample
print data_recommend.ix[:10,:4]
