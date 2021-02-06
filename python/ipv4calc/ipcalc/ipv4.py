import re


class IPv4:
    """
    Class for IP version 4 calc e validation
    """

    def __init__(self, ip: str, prefix: int = 32):
        self.ip_address = ip
        self.net_prefix = prefix
        self.net_mask = '0.0.0.0'
        self.__range_of_ip_adress = None

    @property
    def ip_address(self):
        return self.__ip_address

    @property
    def net_mask(self):
        return self.__net_mask

    @property
    def net_prefix(self):
        return self.__net_prefix

    @property
    def bits_for_subnet(self):
        return self.__bits_for_subnet

    @ip_address.setter
    def ip_address(self, value: str):
        if not self.validate_ip_number(value):
            raise ValueError('Invalid IP Address')
        else:
            self.__ip_address = [int(x) for x in str(value).split('.')]

    @net_mask.setter
    def net_mask(self, value: str):
        self.__net_mask = value

    @net_prefix.setter
    def net_prefix(self, value: int):
        if not value:
            return

        if not isinstance(value, int):
            raise TypeError('Invalide prefix type')

        if value > 32 or value < 1:
            raise ValueError('Invalid prefix')

        self.__net_prefix = value

    @staticmethod
    def validate_ip_number(ip_number: str):
        """
        Validate IP octets numbers

        :params ip_number: A IP address in the format aaa.bbb.ccc.ddd
        :type ip_number: str

        :return: A boolean result indicate if the IP number is valid or not
        :rtype: boolean
        """

        regex = re.compile(
            r'^([0-9]{1,3}).([0-9]{1,3}).([0-9]{1,3}).([0-9]{1,3})$'
        )
        regex_validation = regex.search(ip_number)
        if regex_validation is None:
            return False

        octets = [bin(int(x)) for x in str(ip_number).split('.')]

        if len(octets) != 4:
            return False

        for block in octets:
            block_value = int(block, 2)
            if block_value > 254:
                print('primeiro if')
                return False
            elif (block == octets[0] or block == octets[3]) and block_value < 1:
                print('segundo if')
                return False
            elif (block == octets[1] or block == octets[2]) and block_value < 0:
                print('terceiro if')
                return False
            else:
                continue

    def _calc_network_mask(self):
        number_of_octets = int(self.net_prefix / 8)
        octets = [255 for __ in range(number_of_octets)]
        self.__bits_for_subnet = int(self.net_prefix % 8)

        if self.net_prefix - (number_of_octets * 8) > 0:
            final_octet = ''.join(['1' for __ in range(self.bits_for_subnet)])
            final_octet = f'{final_octet:0<8}'
            octets.append(int(final_octet, 2))

        if len(octets) < 4:
            octets.append(0)

        if octets:
            mask = [str(x) for x in octets]
            self.net_mask = '.'.join(mask)
            print(self.net_mask)

    def _calc_subnets(self):
        number_of_octets = int(self.net_prefix / 8)
        octets = [255 for __ in range(number_of_octets)]
        self.__bits_for_subnet = int(self.net_prefix % 8)

    def _create_ip_address_range(self):
        number_of_octets = int(self.net_prefix / 8)
        if self.net_prefix - (number_of_octets * 8) < 0:
            raise ValueError('Invalid network mask')

        prefix_module = int(self.net_prefix % 8)
        final_octet = ''.join(['1' for __ in range(prefix_module)])
        final_octet = f'{final_octet:0<8}'
        total_hosts = 254 - int(final_octet, 2)
        # print(total_hosts, bin(total_hosts))        
        initial_format = f'{self.ip_address[0]}.{self.ip_address[1]}.{self.ip_address[2]}.'
        self.__range_of_ip_adress = [f'{initial_format}{str(x + 1)}' for x in range(total_hosts)]
        # print(self.__range_of_ip_adress)

    def calculate_network_range_of_ips(self):
        if self.ip_address is None:
            raise ReferenceError('Reference IP not informed')

        self._calc_network_mask()
        self._calc_subnets()
        self._create_ip_address_range()

        address = [f'{ip} / {self.net_mask}' for ip in self.__range_of_ip_adress]
        return address
