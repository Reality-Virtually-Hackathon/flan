
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


CLIENT_ID = "my_client_id"
CLIENT_SECRET = "my_client_secret"


# API constants, you shouldn't have to change these.
API_HOST = 'https://api.yelp.com'
SEARCH_PATH = '/v3/businesses/search'
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
        print (reviews_of_restaurant)
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
