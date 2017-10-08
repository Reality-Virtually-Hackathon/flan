import pandas as pd
from scipy.spatial.distance import cosine


data = pd.read_csv('encoded_x.csv')



data_i = pd.DataFrame(index=data.columns,columns=data.columns)


for i in range(0,len(data_i.columns)) :

    for j in range(0,len(data_i.columns)) :

      data_i.ix[i,j] = 1-cosine(data.ix[:,i],data.ix[:,j])

data_similar = pd.DataFrame(index=data_i.columns,columns=[range(1,9)])
for i in range(0,len(data_i.columns)):
    data_similar.ix[i,:8] = data_i.ix[0:,i][:8].index

print (data_similar)

