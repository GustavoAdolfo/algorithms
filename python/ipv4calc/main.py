"""
Start utilization with user interaction
"""

import os

from ipcalc.ipv4 import IPv4

user_ip = input('Enter a IP number (ex.: 10.10.10.10): ')
network_prefix = input('Type the network prefix value or press "Enter" for default (32): ')

network_prefix = int(network_prefix) if network_prefix else 32

ipv4 = IPv4(user_ip, network_prefix)
ipv4.ip_address = user_ip
result = ipv4.calculate_network_range_of_ips()
print(f'{len(result)} IP addresses calculated')

save_result = input('Save results in a txt file? ([Y/S] / N) ')
if save_result.capitalize() == 'S' or save_result.capitalize() == 'Y':
    local_path = os.path.dirname(os.path.abspath(__file__))
    result_file = os.path.join(local_path, 'IPs.txt')
    with open(result_file, 'w') as ips_file:
        for ip in result:
            ips_file.write(f'{ip}\n')
    print('IPs.txt file saved.')
elif save_result.capitalize() == 'N':
    print_result = input('Print IPs list? ([Y/S], N) ')
    if print_result.capitalize() == 'S' or print_result.capitalize() == 'Y':
        for ip in result:
            print(ip)
else:
    print('Command not found')
