import unittest
from ipcalc.ipv4 import IPv4


class TestIPv4(unittest.TestCase):
    """
    Tests for ipv4 class
    """

    def test_calc_correct_subnet(self):
        calc = IPv4('192.168.0.1', 24)
        self.assertEqual(calc.net_mask, '255.255.248.0')


unittest.main()
