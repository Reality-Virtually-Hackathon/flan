import numpy as np
import pandas as pd
import json
import csv
import pandas as pd
from sklearn.neighbors import KNeighborsClassifier
from sklearn.naive_bayes import GaussianNB
from numpy import genfromtxt

x_temp = np.asarray(genfromtxt('x.csv', delimiter=',', dtype='str'))
x = (x_temp.view(np.ubyte)-96).astype('int32')
y = np.asarray(genfromtxt('y.csv', delimiter=','))
print (x)
print (y)


model = GaussianNB()
model.fit(x, y)

predicted= model.predict([209,210,209,211,209,214,209,217,210,209,210,213,210,212,210,211])
print predicted
