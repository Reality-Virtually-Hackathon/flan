
from __future__ import print_function

import argparse
import json
import pprint
import requests
import sys
import urllib
from urllib2 import HTTPError
from urllib import quote
from urllib import urlencode


CLIENT_ID = "vNvfdKjerL5i7dP_tSnaHw"
CLIENT_SECRET = "jXw2Z0M7cbjLXnZLs2io8n5z8cqaY6dnwj6BMBPlmhsG9eH2ovuoAMxiyyvjC706"


# API constants, you shouldn't have to change these.
API_HOST = 'https://api.yelp.com'
BUSINESS_PATH = '/v3/businesses/'  # Business ID will come after slash.
REVIEWS_PATH = BUSINESS_PATH + 'genghis-china-chinese-food-salem/reviews'
TOKEN_PATH = '/oauth2/token'
GRANT_TYPE = 'client_credentials'


# Defaults for our simple example.
DEFAULT_TERM = 'dinner'
DEFAULT_LOCATION = 'Boston, MA'
SEARCH_LIMIT = 3


def obtain_bearer_token(host, path):

    url = '{0}{1}'.format(host, quote(path.encode('utf8')))
    assert CLIENT_ID, "vNvfdKjerL5i7dP_tSnaHw"
    assert CLIENT_SECRET, "jXw2Z0M7cbjLXnZLs2io8n5z8cqaY6dnwj6BMBPlmhsG9eH2ovuoAMxiyyvjC706"
    data = urlencode({
        'client_id': CLIENT_ID,
        'client_secret': CLIENT_SECRET,
        'grant_type': GRANT_TYPE,
    })
    headers = {
        'content-type': 'application/x-www-form-urlencoded',
    }
    response = requests.request('POST', url, data=data, headers=headers)
    bearer_token = response.json()['access_token']
    return bearer_token


def request(host, path, bearer_token, url_params=None):

    url_params = url_params or {}
    url = '{0}{1}'.format(host, quote(path.encode('utf8')))
    headers = {
        'Authorization': 'Bearer %s' % bearer_token,
    }

    response = requests.request('GET', url, headers=headers, params=url_params)

    return response.json()


def main():

    try:
        bearer_token = obtain_bearer_token(API_HOST, TOKEN_PATH)
        reviews_of_restaurant = request(API_HOST, REVIEWS_PATH, bearer_token)

        for i in range(0, 3):
            text_review = reviews_of_restaurant["reviews"][i]["text"]
            rating = reviews_of_restaurant["reviews"][i]["rating"]
            print (text_review)
            print (rating)
    except HTTPError as error:
        sys.exit(
            'HTTP error occured {0} on {1}:\n {2}\n'.format(
                error.code,
                error.url,
                error.read(),
            )
        )


if __name__ == '__main__':
    main()

'''
with open("sample-data.json") as file:
    data = json.load(file)
    numpy_2d_arrays = [np.array(i) for i in data["flan"]]

df = pd.DataFrame(numpy_2d_arrays)
print (df)

df[['rating','base','toppings','protein','sauce','size']] = pd.DataFrame(df.values.tolist())

for i in range (0,25):
    y = np.append(y, my_data[i][8])
    x = np.append(x, my_data[i][:8])

11: small bowl
12: large bowl
brown-rice = 13
white-rice 14
vermi noodles 15
Chicken 16
Tofu 17
beef  18
peanut sauce 19
soy sauce 20
peanuts 21
cucumbers 22
scallions 23
sprouts 24
carrots 25
Jalapenos 26
Lime Fish Sauce 27
Pickled Daikon 28

'''
