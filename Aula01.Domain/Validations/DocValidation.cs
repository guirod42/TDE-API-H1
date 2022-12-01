﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain.Validations
{

    public class ValidDoc
    {
        public ValidDoc(string message, bool status, string numbers)
        {
            Message = message;
            Status = status;
            Numbers = numbers;
        }

        public string Message { get; set; }
        public bool Status { get; set; }
        public string Numbers { get; set; }
    }

    public static class DocValidation
    {
        public static ValidDoc ValidCPF(string cpf)
        {
            return !CpfValidacao.Validar(cpf)
                ? new ValidDoc("Documento inválido", false, Utils.ApenasNumeros(cpf))
                : new ValidDoc("Documento válido", true, Utils.ApenasNumeros(cpf));
        }
        
        public static ValidDoc ValidCNPJ(string cnpj)
        {
            return !CnpjValidacao.Validar(cnpj)
                ? new ValidDoc("Documento inválido", false, Utils.ApenasNumeros(cnpj))
                : new ValidDoc("Documento válido", true, Utils.ApenasNumeros(cnpj));
        }
        
        private class CpfValidacao
        {
            public const int TamanhoCpf = 11;

            public static bool Validar(string cpf)
            {
                var cpfNumeros = Utils.ApenasNumeros(cpf);

                if (!TamanhoValido(cpfNumeros)) return false;
                return !TemDigitosRepetidos(cpfNumeros) && TemDigitosValidos(cpfNumeros);
            }

            private static bool TamanhoValido(string valor)
            {
                return valor.Length == TamanhoCpf;
            }

            private static bool TemDigitosRepetidos(string valor)
            {
                string[] invalidNumbers =
                {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
                return invalidNumbers.Contains(valor);
            }

            private static bool TemDigitosValidos(string valor)
            {
                var number = valor.Substring(0, TamanhoCpf - 2);
                var digitoVerificador = new DigitoVerificador(number)
                    .ComMultiplicadoresDeAte(2, 11)
                    .Substituindo("0", 10, 11);
                var firstDigit = digitoVerificador.CalculaDigito();
                digitoVerificador.AddDigito(firstDigit);
                var secondDigit = digitoVerificador.CalculaDigito();

                return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCpf - 2, 2);
            }
        }
        private class CnpjValidacao
    {
        public const int TamanhoCnpj = 14;

        public static bool Validar(string cpnj)
        {
            var cnpjNumeros = Utils.ApenasNumeros(cpnj);

            if (!TemTamanhoValido(cnpjNumeros)) return false;
            return !TemDigitosRepetidos(cnpjNumeros) && TemDigitosValidos(cnpjNumeros);
        }

        private static bool TemTamanhoValido(string valor)
        {
            return valor.Length == TamanhoCnpj;
        }

        private static bool TemDigitosRepetidos(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(valor);
        }

        private static bool TemDigitosValidos(string valor)
        {
            var number = valor.Substring(0, TamanhoCnpj - 2);

            var digitoVerificador = new DigitoVerificador(number)
                .ComMultiplicadoresDeAte(2, 9)
                .Substituindo("0", 10, 11);
            var firstDigit = digitoVerificador.CalculaDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalculaDigito();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCnpj - 2, 2);
        }
    }
        private class DigitoVerificador
    {
        private string _numero;
        private const int Modulo = 11;
        private readonly List<int> _multiplicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public DigitoVerificador(string numero)
        {
            _numero = numero;
        }

        public DigitoVerificador ComMultiplicadoresDeAte(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multiplicadores.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multiplicadores.Add(i);

            return this;
        }

        public DigitoVerificador Substituindo(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substituicoes[i] = substituto;
            }
            return this;
        }

        public void AddDigito(string digito)
        {
            _numero = string.Concat(_numero, digito);
        }

        public string CalculaDigito()
        {
            return !(_numero.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                soma += produto;

                if (++m >= _multiplicadores.Count) m = 0;
            }

            var mod = (soma % Modulo);
            var resultado = _complementarDoModulo ? Modulo - mod : mod;

            return _substituicoes.ContainsKey(resultado) ? _substituicoes[resultado] : resultado.ToString();
        }
    }
        private class Utils
        {
            public static string ApenasNumeros(string valor)
            {
                var onlyNumber = "";
                foreach (var s in valor)
                {
                    if (char.IsDigit(s))
                    {
                        onlyNumber += s;
                    }
                }
                return onlyNumber.Trim();
            }
        }
    }
}
